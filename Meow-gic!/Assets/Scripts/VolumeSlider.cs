using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer gameAudio;
    public Slider slider;
    public GameObject textSliderValue;
    public float volume;

    void Awake()
    {

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameAudio");

        if (musicObj.Length > 1)
        {

            Destroy(this.gameObject);

        }


        DontDestroyOnLoad(this.gameObject);

    }

    void Start()
    {

        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        volume = slider.value;
    }

    void Update()
    {
        if (textSliderValue != null)
        {
            textSliderValue.GetComponent<TextMeshProUGUI>().SetText("Volume: " + Mathf.Round(slider.value * 100));
        }
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        volume = slider.value;

    }

    public void SetVolume(float volume)
    {

        gameAudio.SetFloat("GameVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);

    }

}
