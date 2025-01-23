using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ScreenSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    private List<Resolution> resolutions;

    private void Awake()
    {
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

    void Start()
    {
        SetResolutionDropDown();
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


    private void SetResolutionDropDown()
    {
        resolutions = GetScreenResolutions();

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

    private List<Resolution> GetScreenResolutions()
    {
        List<Resolution> myResolutions = new List<Resolution>();

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

            myResolutions.Add(Screen.resolutions[i]);
        }

        return myResolutions;
    }
}