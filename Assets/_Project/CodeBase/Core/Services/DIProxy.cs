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
        public override void RegisterServices(DI di)
        {
            di.RegisterService().ByInstance<UILayerDisposer>(layerDisposer).AsProject().Done();
        }
    }
}
