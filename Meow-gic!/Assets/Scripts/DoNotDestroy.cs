using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    public int lives = 9;
    public int healthUpgradeLevel = 0;
    public int healthUpgradePrice = 50;
    public int projectileUpgradeLevel = 0;
    public int projectileUpgradePrice = 25;
    public float maxHealth = 10f;
    public int strength = 1;
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
