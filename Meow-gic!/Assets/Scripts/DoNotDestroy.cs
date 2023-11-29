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
        GameObject[] gameManagerObj = GameObject.FindGameObjectsWithTag("GameManager");

        if (gameManagerObj.Length > 1)
        {

            Destroy(this.gameObject);

        }
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
