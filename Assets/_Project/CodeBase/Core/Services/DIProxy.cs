using MainCore.Maintenance.ServiceDI.RegistrationDependencies.Descriptions;
using MainCore.Maintenance.ServiceDI.RegistrationDependencies;
using CodeBase.UI.Layers.LayerDisposer;
using MainCore.Maintenance.ServiceDI;
using UnityEngine;
using System;

namespace CodeBase.Core.Services
{
    internal class DIProxy : RegistrationServicesProxyBase
    {
        [SerializeField] private UILayerDisposer layerDisposer;
        [SerializeField] private NetworkService networkDisposer;
        [SerializeField] private SettingsService settingsService;
        public override void RegisterServices(DI di)
        {
            di.RegisterService().ByInstance<UILayerDisposer>(layerDisposer).AsProject().Done();
            di.RegisterService().ByInstance<NetworkService>(networkDisposer).AsProject().Done();
            di.RegisterService().ByInstance<SettingsService>(settingsService).AsProject().Done();
        }
    }
}
