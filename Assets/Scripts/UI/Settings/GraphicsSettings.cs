using TMPro;
using UnityEngine;

public class GraphicsSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown qualityDropdown;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("GameQuality"))
        {
            int qualityIndex = PlayerPrefs.GetInt("GameQuality");
            QualitySettings.SetQualityLevel(qualityIndex);
            qualityDropdown.value = qualityIndex;
        }
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("GameQuality", qualityIndex);
    }
}
