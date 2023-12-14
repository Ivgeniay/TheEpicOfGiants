using CodeBase.CodeBase.SpawnPoint;
using System.Collections.Generic; 
using CodeBase.Utility; 
using UnityEngine;
using System.Linq;

namespace CodeBase.Core.Services
{
    internal class SpawnService : MonoBehaviour
    {
        private NetworkService networkService;
        private Repository<Spawner> repository = new();
        public void Construct(NetworkService networkService)
        {
            this.networkService = networkService;
        }
        
        public void Register(Spawner spawner) => repository.Register(spawner);
        public void Unregister(Spawner spawner) => repository.Unregister(spawner);

        public T Instantiate<T>()
        {
            Spawner spawner = repository.First(e => e.IsType<T>());
            GameObject instance = null;
            if (networkService.IsConnected) instance = spawner.PhotonSpawn();
            else instance = spawner.Spawn();
            return instance.GetComponentInChildren<T>(true);
        }
    }
}
