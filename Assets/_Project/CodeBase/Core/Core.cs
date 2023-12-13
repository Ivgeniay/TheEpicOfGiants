using MainCore.Maintenance.ServiceDI;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Core
{
    internal class Core : MonoBehaviour
    {
        [SerializeField] private Boostap boostap;

        private static Core instance;
        public static Core Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindFirstObjectByType<Core>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (Core.Instance != this) Destroy(gameObject);
            SceneManager.activeSceneChanged += OnActiveSceneChangedHandler;
            DontDestroyOnLoad(gameObject);

        }

        private void OnActiveSceneChangedHandler(Scene arg0, Scene arg1)
        {
            boostap.Boostrap();
        }

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => boostap.isLoaded);
        }
    }
}
