using CodeBase.UI.Layers.LayerDisposer;
using CodeBase.UI.Layers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.UI.MenuCallbacks
{
    internal class CallbacksMainMenu : MonoBehaviour
    {
        private UILayerDisposer disposer;
        [SerializeField] private SceneEnum gameplayScene;

        public void Construct(UILayerDisposer disposer)
        {
            this.disposer = disposer;
        }

        public void Exit() => Application.Quit();
        public void Back() => disposer.ChangeLayer(disposer.PrevLayerType);
        public void Hero() => disposer.ChangeLayer(disposer.PrevLayerType);
        public void Titan()
        {
            SceneManager.LoadSceneAsync(gameplayScene.ToString(), LoadSceneMode.Single);
            //disposer.ChangeLayer(disposer.PrevLayerType);
        }
        public void StartGame() => disposer.ChangeLayer(LayerType.RoleLayer);
        
    }
}
