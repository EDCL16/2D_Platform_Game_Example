using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelSelectPanel : MonoBehaviour
{
    private void Start()
    {
        // 取得所有子物件中的 Button
        for (int i = 0; i < transform.childCount; i++)
        {
            int levelNumber = i + 1;
            GameObject button = transform.GetChild(i).gameObject;
            button.GetComponent<SceneChangeManager>().sceneName = "Level " + levelNumber;
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = levelNumber.ToString();
        }
    }
}
