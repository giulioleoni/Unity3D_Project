using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class SettingsMenu : MonoBehaviour
{
    //[SerializeField] private AudioMixer master;
    [SerializeField] private TMP_Text volumeValueText;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private List<Resolution> resolutions;


    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);

        resolutions = new List<Resolution>();

        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (i > 0)
            {
                if (Screen.resolutions[i].width == Screen.resolutions[i - 1].width &&
                    Screen.resolutions[i].height == Screen.resolutions[i - 1].height)
                {
                    continue;
                }
            }

            resolutions.Add(Screen.resolutions[i]);
        }

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetGameVolume(float volume)
    {
        //master.SetFloat("MasterVolume", volume);
        AudioListener.volume = volume;
        volumeValueText.text = volume.ToString("0.0");
        PlayerPrefs.SetFloat("GameVolume", volume);
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void ToggleFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetScreenResolution(int resolutionIndex)
    {
        Resolution targetResolution = resolutions[resolutionIndex];
        Screen.SetResolution(targetResolution.width, targetResolution.height, Screen.fullScreen);
    }
}
