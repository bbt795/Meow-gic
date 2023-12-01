using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VillageUI : MonoBehaviour
{

    private GameObject gameManager;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        
    }

    // Update is called once per frame
    void Update()
    {

        livesText.text = "" + gameManager.GetComponent<DoNotDestroy>().lives;
        goldText.text = "" + gameManager.GetComponent<DoNotDestroy>().gold;
        
    }
}
