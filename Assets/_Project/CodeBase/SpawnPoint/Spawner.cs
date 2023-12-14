using UnityEngine;
using Photon.Pun;
using CodeBase.Core.Services;

namespace CodeBase.CodeBase.SpawnPoint
{
    internal class Spawner : MonoBehaviourPun
    {
        [SerializeField] protected GameObject prefab;

        public const string PATH_PREFIX = @"Instances\";
        private SpawnService spawnService;

        public void Construct(SpawnService spawnService)
        {
            this.spawnService = spawnService;
            spawnService.Register(this);
        }

        private void OnEnable()
        {
            spawnService.Register(this);
        }
        private void OnDisable()
        {
            spawnService.Unregister(this);
        }

        internal GameObject Spawn()
        {
            return Instantiate(prefab, transform.position, transform.rotation);
        }

        internal GameObject PhotonSpawn()
        {
            return PhotonNetwork.Instantiate(prefab.name, transform.position, transform.rotation);
        }

        internal bool IsType<T>() => prefab.GetComponentInChildren<T>(true) != null;
        
    }
}
