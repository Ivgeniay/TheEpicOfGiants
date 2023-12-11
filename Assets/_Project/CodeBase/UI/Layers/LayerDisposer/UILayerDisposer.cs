using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.UI.Layers.LayerDisposer
{
    internal class UILayerDisposer : MonoBehaviour
    { 
        public LayerType CurrentLayerType { get; private set; }
        public LayerType PrevLayerType { get; private set; }

        private List<UILayer> uiLayers = new();
        
        public void RegisterLayer(UILayer uILayer)
        {
            if (!uiLayers.Contains(uILayer))
                uiLayers.Add(uILayer);
        }
        public void UnregisterLayer(UILayer uILayer)
        {
            if (!uiLayers.Contains(uILayer))
                uiLayers.Remove(uILayer);
        }

        public void ChangeLayer(LayerType layer)
        {
            PrevLayerType = CurrentLayerType;
            CurrentLayerType = layer;
            foreach (UILayer uILayer in uiLayers)
                uILayer.Enable(uILayer.LayerType == layer);
        }
    }
}
