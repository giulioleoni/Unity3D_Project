using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer master;

    public void SetVolume(float volume)
    {
        master.SetFloat("MasterVolume", volume);
    }
}
