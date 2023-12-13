using CodeBase.UI.Layers.LayerDisposer;
using CodeBase.UI.Layers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using CodeBase.Core.Services;

namespace CodeBase.UI.MenuCallbacks
{
    internal class CallbacksMainMenu : MonoBehaviour
    {
        [SerializeField] private SceneEnum gameplayScene;

        private UILayerDisposer disposer;
        private SettingsService settingsService;

        public void Construct(UILayerDisposer disposer, SettingsService settingsService)
        {
            this.disposer = disposer;
            this.settingsService = settingsService;
        }

        public void Exit() => Application.Quit();
        public void Back() => disposer.ChangeLayer(disposer.PrevLayerType);
        public void Hero() => disposer.ChangeLayer(disposer.PrevLayerType);
        public void Titan()
        {
            if (settingsService.CheckXRDevice())
            {
                SceneManager.LoadSceneAsync(gameplayScene.ToString(), LoadSceneMode.Single);
            }
            else
            {
                Debug.LogError("XR not founded");
            }
        }
        public void StartGame() => disposer.ChangeLayer(LayerType.RoleLayer);

        
    }
}
