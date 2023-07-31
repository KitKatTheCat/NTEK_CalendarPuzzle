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
    [SerializeField] private GameObject TitleUIHolder;
    [SerializeField] private Button[] graphicsQuality;

    [SerializeField] private Slider VolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
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
        TitleUIHolder.SetActive(true);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityValue", qualityIndex);
    }
}
