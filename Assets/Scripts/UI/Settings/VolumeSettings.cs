using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer master;
    [SerializeField] private Slider volumeSlider;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("GameVolume"))
        {
            float volume = PlayerPrefs.GetFloat("GameVolume");
            master.SetFloat("MasterVolume", volume);
            volumeSlider.value = Mathf.Pow(10, volume / 20);
        }
    }

    public void SetGameVolume(float volume)
    {
        float newVolume = Mathf.Log10(volume) * 20;
        master.SetFloat("MasterVolume", newVolume);
        PlayerPrefs.SetFloat("GameVolume", newVolume);
    }
}
