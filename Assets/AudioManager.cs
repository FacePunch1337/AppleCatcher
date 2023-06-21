using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip mainMusicClip;
    public AudioClip successClip;
    public AudioClip failureClip;

    private void Start()
    {
        // Воспроизведение основной мелодии
        PlayMainMusic();
    }

    public void PlayMainMusic()
    {
        // Установка основной мелодии на источнике звука и запуск воспроизведения
        musicSource.clip = mainMusicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySuccessSound()
    {
        // Воспроизведение звука при попадании яблока в корзину
        AudioSource.PlayClipAtPoint(successClip, transform.position);
    }

    public void PlayFailureSound()
    {
        // Воспроизведение звука при неудаче
        AudioSource.PlayClipAtPoint(failureClip, transform.position);
    }
}
