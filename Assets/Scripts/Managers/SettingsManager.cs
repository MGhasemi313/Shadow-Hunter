using UnityEngine;
using UnityEngine.UI;


public class SettingsManager : MonoBehaviour
{

    public Slider volumeSlider;


    void Start()
    {
        // volumeSlider.value =
        // PlayerPrefs.GetFloat(
        // "Volume",
        // 1);
    }


    public void ChangeVolume(float value)
    {
        Debug.Log("Slider Value : " + value);
        AudioManager.Instance
        .SetVolume(value);
    }

}