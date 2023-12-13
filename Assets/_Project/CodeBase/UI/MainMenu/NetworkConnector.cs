using CodeBase.UI.Layers.LayerDisposer;
using CodeBase.Core.Services;
using UnityEngine;
using System.Collections;

namespace CodeBase.UI.MainMenu
{
    internal class NetworkConnector : MonoBehaviour
    {
        private NetworkService networkService;
        private UILayerDisposer uILayerDisposer;

        public void Construct(NetworkService networkService, UILayerDisposer uILayerDisposer)
        {
            this.networkService = networkService;
            this.uILayerDisposer = uILayerDisposer;

            this.networkService.Connect();
        }

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => networkService != null);
            yield return new WaitUntil(() => networkService.IsConnected);

            uILayerDisposer.ChangeLayer(Layers.LayerType.MainLayer);
        }
    }
}
