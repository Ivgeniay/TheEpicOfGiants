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

    public void Boostrap()
    {
        PrepaireDI();
        isLoaded = true;
    }

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => isLoaded);
        isLoaded = true;
        SceneManager.LoadSceneAsync(mainMenuScene.ToString(), LoadSceneMode.Single);
    }
     
}
