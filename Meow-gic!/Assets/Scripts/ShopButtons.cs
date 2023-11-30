using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ShopButtons : MonoBehaviour
{
    public GameObject gameManager;
    // public GameObject healthPriceDisplay;
    // public TextMeshProUGUI healthPriceDisplayText;
    // public GameObject healthPriceDisplay;
    // public TextMeshProUGUI healthPriceDisplayText;
    public GameObject goldDisplay;
    public TextMeshProUGUI goldDisplayText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
