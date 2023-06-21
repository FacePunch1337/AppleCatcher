using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip mainMusicClip;
    public AudioClip successClip;
    public AudioClip failureClip;

    private void Start()
    {
        // ��������������� �������� �������
        PlayMainMusic();
    }

    public void PlayMainMusic()
    {
        // ��������� �������� ������� �� ��������� ����� � ������ ���������������
        musicSource.clip = mainMusicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySuccessSound()
    {
        // ��������������� ����� ��� ��������� ������ � �������
        AudioSource.PlayClipAtPoint(successClip, transform.position);
    }

    public void PlayFailureSound()
    {
        // ��������������� ����� ��� �������
        AudioSource.PlayClipAtPoint(failureClip, transform.position);
    }
}
