using UnityEngine;

public class EndPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneChangeManager sceneChangeManager = FindFirstObjectByType<SceneChangeManager>();
            sceneChangeManager.ChangeScene("LevelSelect");
        }
    }
}
