using MainCore.Maintenance.Boostraper;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boostap : BaseBoostrap
{
    [SerializeField] private SceneEnum nextScene;

    private IEnumerator Start()
    {
        yield return null;
        SceneManager.LoadSceneAsync(nextScene.ToString(), LoadSceneMode.Single);
    }
     
    void Update()
    {
        
    }
}
