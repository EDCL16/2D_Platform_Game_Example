using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinCountText;
    int coinCount = 0;
    public void GetOneCoin()
    {
        coinCount++;
        coinCountText.text = coinCount.ToString();
    }
}
