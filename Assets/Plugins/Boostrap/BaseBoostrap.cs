using MainCore.Maintenance.ServiceDI.RegistrationDependencies; 
using MainCore.Maintenance.Boostraper.AppConfiguration;
using MainCore.Maintenance.ServiceDI;
using UnityEngine;

namespace MainCore.Maintenance.Boostraper
{
    public abstract class BaseBoostrap : MonoBehaviour
    {
        [SerializeField] protected Config applicationConfiguration;
        [SerializeField] private bool isGlobalMonoInject = true;

        private DI di = new(); 

        protected virtual void Awake()
        { 
            RegisterServices(di);
            ProxyRegistration(di);
            di.Build();
            if (isGlobalMonoInject) GlobalInject();
            DontDestroyOnLoad(gameObject);
        } 

        protected virtual void RegisterServices(DI di) {} 

        private void ProxyRegistration(DI di)
        {
            var proxies = FindObjectsByType<RegistrationServicesProxyBase>(
                findObjectsInactive: FindObjectsInactive.Include, 
                sortMode: FindObjectsSortMode.None);
            if (proxies.Length > 0)
            {
                foreach (var item in proxies)
                    item.RegisterServices(di);
                
            }
        }

        private void GlobalInject()
        {
            var monos = FindObjectsByType<MonoBehaviour>(
                findObjectsInactive: FindObjectsInactive.Include,
                sortMode: FindObjectsSortMode.None);

            foreach (var scr in monos) 
                di.MonoInject(scr);
        }

    }

}
