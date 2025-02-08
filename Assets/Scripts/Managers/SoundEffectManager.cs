using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    [SerializeField] GameObject soundEffectPrefab;

    public void PlaySoundEffect(AudioClip soundEffect)
    {
        GameObject soundGameObject = Instantiate(soundEffectPrefab);

        //確保soundEffectPrefab 上面有附加AudioSource 的componenet
        AudioSource audioSource = soundGameObject.GetComponent<AudioSource>();

        audioSource.clip = soundEffect;
        audioSource.Play();

        // 延遲 soundEffect.length的時間摧毀soundGameObject
        Destroy(soundGameObject, soundEffect.length);
    }
}
