using MainCore.Maintenance.Boostraper;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boostap : BaseBoostrap
{
    [SerializeField] private SceneEnum mainMenuScene;
    public bool isLoaded { get; private set; } = false;

    protected override void Awake()
    {
        base.Awake();
    }

    private IEnumerator Start()
    {
        if (!isLoaded)
        {
            yield return null;
            isLoaded = true;
            SceneManager.LoadSceneAsync(mainMenuScene.ToString(), LoadSceneMode.Single);
        }
    }
     
}
