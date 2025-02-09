using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeScene(string _thisSceneName)
    {
        SceneManager.LoadScene(_thisSceneName);
    }
    public void ReloadSceneNow()
    {
        ChangeScene(GetCurrentSceneName());
    }
    public string GetCurrentSceneName()
    {
        Scene scene = SceneManager.GetActiveScene();
        return scene.name;
    }
}
