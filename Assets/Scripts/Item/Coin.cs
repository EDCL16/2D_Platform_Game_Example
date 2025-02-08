using UnityEngine;

public class Coin : MonoBehaviour
{
    SoundEffectManager soundEffectManager;
    [SerializeField] AudioClip coinSound;

    void Start()
    {
        //找整個專案，直到找到第一個SoundEffectManager component
        soundEffectManager = FindFirstObjectByType<SoundEffectManager>();
    }

    void OnTriggerEnter2D(Collider2D other)// 物件進入coin的時候會呼叫此函數
    {
        if (!other.CompareTag("Player")) return;

        GetComponent<Collider2D>().enabled = false; // 先停用Collider避免重複觸發
        soundEffectManager.PlaySoundEffect(coinSound);
        FindFirstObjectByType<CoinUI>().GetOneCoin();
        Destroy(gameObject);
    }

}
