using MainCore.Maintenance.ServiceDI.ExMonoBehaviour;
using CodeBase.UI.Layers.LayerDisposer;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.Layers
{
    internal class UILayer : DiMonoBehaviour
    {
        [SerializeField] private LayerType layerType;
        private UILayerDisposer disposer;
        public LayerType LayerType { get {  return layerType; } }

        public void Construct(UILayerDisposer disposer)
        {
            this.disposer = disposer;
            disposer.RegisterLayer(this);
        }

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnEnable() => disposer?.RegisterLayer(this); 
        private void OnDisable() => disposer?.UnregisterLayer(this);

        public void Enable(bool value)
        {
            foreach (Transform child in gameObject.transform)
                child?.gameObject.SetActive(value);
        }

    }
}
