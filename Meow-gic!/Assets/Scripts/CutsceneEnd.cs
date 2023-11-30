using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneEnd : MonoBehaviour
{

    public VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {

        player.loopPointReached += NextScene;

    }

    private void NextScene(VideoPlayer player)
    {

        SceneManager.LoadScene(2);

    }

}
