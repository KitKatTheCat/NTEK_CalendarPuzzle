using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class Options : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject OptionsUIHolder;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Button[] FPSLimit;
    [SerializeField] private Button[] graphicsQuality;
    private int FPSLimitValue;

    [SerializeField] private Slider VolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = PlayerPrefs.GetInt("FPSLimitValue");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityValue"));
        VolumeSlider.value = PlayerPrefs.GetFloat(key: "Volume");
    }

    public void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
    }

    public void OptionReturn()
    {
        SaveVolumeSettings();
        MainMenuUI.SetActive(true);
        OptionsUIHolder.SetActive(false);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityValue", qualityIndex);
    }

    public void SetFPSLimit(int fpsIndex)
    {
        int newFPSLimit = fpsIndex switch
        {
            0 => 30,
            1 => 60,
            _ => Application.targetFrameRate
        };

        PlayerPrefs.SetInt("FPSLimitValue", newFPSLimit);
        FPSLimitValue = newFPSLimit;
        Application.targetFrameRate = newFPSLimit;
    }
}
