using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipButton : MonoBehaviour
{

    public void Skip()
    {
        if(SceneManager.GetActiveScene().name == "OpeningCutscene")
        {

            SceneManager.LoadScene(2);

        } else if (SceneManager.GetActiveScene().name == "EndingCutscene")
        {

            SceneManager.LoadScene(0);

        }

    }

}
