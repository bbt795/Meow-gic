using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    public int lives = 9;
    public float gold;
    private void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Forest")
        {

            

        }
    }
}
