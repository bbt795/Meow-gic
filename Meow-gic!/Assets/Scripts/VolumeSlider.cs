using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer gameAudio;
    public Slider slider;
    public GameObject textSliderValue;

    void Start()
    {

        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);

    }

    void Update()
    {

        textSliderValue.GetComponent<TextMeshProUGUI>().SetText("Volume: " + Mathf.Round(slider.value * 100));

    }

    public void SetVolume(float volume)
    {

        gameAudio.SetFloat("GameVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);

    }

}
