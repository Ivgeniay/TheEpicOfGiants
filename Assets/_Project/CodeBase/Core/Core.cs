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
            DontDestroyOnLoad(gameObject);
        }

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => boostap.isLoaded);
        }
    }
}
