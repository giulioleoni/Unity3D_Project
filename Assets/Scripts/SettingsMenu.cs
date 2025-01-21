using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class SettingsMenu : MonoBehaviour
{
    [Header("VolumeSettings")]
    [SerializeField] private AudioMixer master;
    [SerializeField] private TMP_Text volumeValueText;
    [SerializeField] private Slider volumeSlider;

    [Header("Screen settings")]
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    private List<Resolution> resolutions;
    //private bool fullScreen;
    //private int quality;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("GameVolume"))
        {
            float volume = PlayerPrefs.GetFloat("GameVolume");
            AudioListener.volume = volume;
            volumeValueText.text = volume.ToString("0.0");
            volumeSlider.value = volume;
        }

        if (PlayerPrefs.HasKey("GameQuality"))
        {
            int qualityIndex = PlayerPrefs.GetInt("GameQuality");
            QualitySettings.SetQualityLevel(qualityIndex);
            qualityDropdown.value = qualityIndex;
        }

        if (PlayerPrefs.HasKey("FullScreen"))
        {
            int fullScreen = PlayerPrefs.GetInt("GameQuality");

            Screen.fullScreen = fullScreen == 1 ? true : false;
            fullScreenToggle.isOn = Screen.fullScreen; 
        }


        if (PlayerPrefs.HasKey("ScreenWidth") && (PlayerPrefs.HasKey("ScreenHeight")))
        {
            int width = PlayerPrefs.GetInt("ScreenWidth");
            int height = PlayerPrefs.GetInt("ScreenHeight");
            Debug.Log(width + " x " + height);

            Screen.SetResolution(width, height, Screen.fullScreen);
        }


    }

    private void Start()
    {

        SetResolutionDropDown();
        Debug.Log(Screen.fullScreen);
    }

    public void SetGameVolume(float volume)
    {
        //float newVolume = (-30 + (volume * 30));
        //Debug.Log(newVolume);
        //master.SetFloat("MasterVolume", newVolume);
        AudioListener.volume = volume;
        volumeValueText.text = volume.ToString("0.0");
        PlayerPrefs.SetFloat("GameVolume", volume);
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("GameQuality", qualityIndex);
    }

    public void ToggleFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullScreen", (isFullScreen ? 1 : 0));

    }

    public void SetScreenResolution(int resolutionIndex)
    {
        Resolution targetResolution = resolutions[resolutionIndex];
        Screen.SetResolution(targetResolution.width, targetResolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ScreenWidth", targetResolution.width);
        PlayerPrefs.SetInt("ScreenHeight", targetResolution.height);
    }

    public void SetResolutionDropDown()
    {
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
        List<string> resolutionOptions = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
}
