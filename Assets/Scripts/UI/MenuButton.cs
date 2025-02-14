using UnityEngine;

public class MenuButton : MonoBehaviour
{

    public void StartGame()
    {
        SceneChangeManager sceneChangeManager = GetComponent<SceneChangeManager>();
        sceneChangeManager.ChangeScene();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
