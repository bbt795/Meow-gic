using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ShopKeepers : NPC
{
    public GameObject shopPanel;
    public void ShowShop()
    {
        currentLine = 0;
        dialogueText.text = dialogueSet.dialogue[currentLine];
        shopPanel.SetActive(true);

    }

    // Start is called bef
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
