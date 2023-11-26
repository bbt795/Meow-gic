using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceControl : MonoBehaviour
{

    public AudioSource audioSource;
    private GameObject gameAudio;

    // Start is called before the first frame update
    void Start()
    {

        audioSource = this.gameObject.GetComponent<AudioSource>();
        gameAudio = GameObject.FindGameObjectWithTag("GameAudio");
        audioSource.volume = gameAudio.GetComponent<VolumeSlider>().volume;

        if(gameAudio == null)
        {

            audioSource.volume = 0.5f;

        }
        
    }

    // Update is called once per frame
    void Update()
    {

        audioSource.volume = gameAudio.GetComponent<VolumeSlider>().volume;

        if (gameAudio == null)
        {

            audioSource.volume = 0.5f;

        }

    }
}
