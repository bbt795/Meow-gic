using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject instructionsPanel;
    public GameObject creditsPanel;

    public void NewGame()
    {

        SceneManager.LoadScene(1);

    }

    public void SettingsPanel()
    {

        if(mainPanel.activeSelf == true)
        {

            mainPanel.SetActive(false);

        }

        settingsPanel.SetActive(true);

    }

    public void InstructionsPanel()
    {

        if (mainPanel.activeSelf == true)
        {

            mainPanel.SetActive(false);

        }

        instructionsPanel.SetActive(true);

    }

    public void CreditsPanel()
    {

        if (mainPanel.activeSelf == true)
        {

            mainPanel.SetActive(false);

        }

        creditsPanel.SetActive(true);

    }

    public void ExitGame()
    {

        Application.Quit();

    }
}
