using CodeBase.UI.Layers.LayerDisposer;
using UnityEngine.SceneManagement;
using CodeBase.Core.Services;
using CodeBase.UI.Layers;
using UnityEngine.XR;
using UnityEngine;

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
