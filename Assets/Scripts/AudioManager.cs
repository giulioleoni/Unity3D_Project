using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;



    public void PlaySoundEffect(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
