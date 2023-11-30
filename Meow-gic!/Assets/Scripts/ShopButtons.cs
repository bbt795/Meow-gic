using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ShopButtons : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject shopPanel;
    public Sprite[] spriteArray;
    public Button healthUpgradeButton;
    public Button projectileUpgradeButton;
    public GameObject healthPriceDisplay;
    public TextMeshProUGUI healthPriceDisplayText;
    public GameObject projectilePriceDisplay;
    public TextMeshProUGUI projectilePriceDisplayText;
    public GameObject goldDisplay;
    public TextMeshProUGUI goldDisplayText;
    public TextMeshProUGUI dialogueBox;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        healthPriceDisplayText = healthPriceDisplay.GetComponent<TextMeshProUGUI>();
        projectilePriceDisplayText = projectilePriceDisplay.GetComponent<TextMeshProUGUI>();
        goldDisplayText = goldDisplay.GetComponent<TextMeshProUGUI>();

    }

    public void UpgradeHealth(){
        if(gameManager.GetComponent<DoNotDestroy>().gold >= gameManager.GetComponent<DoNotDestroy>().healthUpgradePrice){
            gameManager.GetComponent<DoNotDestroy>().maxHealth += 5;
            gameManager.GetComponent<DoNotDestroy>().gold -= gameManager.GetComponent<DoNotDestroy>().healthUpgradePrice;
            gameManager.GetComponent<DoNotDestroy>().healthUpgradeLevel += 1;
            healthUpgradeButton.image.sprite = spriteArray[gameManager.GetComponent<DoNotDestroy>().healthUpgradeLevel];
            if(gameManager.GetComponent<DoNotDestroy>().healthUpgradeLevel != 4){
                gameManager.GetComponent<DoNotDestroy>().healthUpgradePrice += 50;
            }
        }
    }

    public void UpgradeProjectile(){
        if(gameManager.GetComponent<DoNotDestroy>().gold >= gameManager.GetComponent<DoNotDestroy>().projectileUpgradePrice){
            gameManager.GetComponent<DoNotDestroy>().strength += 1;
            gameManager.GetComponent<DoNotDestroy>().gold -= gameManager.GetComponent<DoNotDestroy>().projectileUpgradePrice;
            gameManager.GetComponent<DoNotDestroy>().projectileUpgradeLevel += 1;
            projectileUpgradeButton.image.sprite = spriteArray[gameManager.GetComponent<DoNotDestroy>().projectileUpgradeLevel];
            if(gameManager.GetComponent<DoNotDestroy>().projectileUpgradeLevel != 4){
                gameManager.GetComponent<DoNotDestroy>().projectileUpgradePrice += 25;
            }
        }
    }

    public void ExitShop(){
        shopPanel.SetActive(false);
    }

    void Update(){
        healthPriceDisplayText.text = "Price: " + gameManager.GetComponent<DoNotDestroy>().healthUpgradePrice;
        projectilePriceDisplayText.text = "Price: " + gameManager.GetComponent<DoNotDestroy>().projectileUpgradePrice;
        goldDisplayText.text = "Gold: " + gameManager.GetComponent<DoNotDestroy>().gold;

        if(gameManager.GetComponent<DoNotDestroy>().healthUpgradeLevel == 4){
                healthUpgradeButton.interactable = false;
            }
        if(gameManager.GetComponent<DoNotDestroy>().projectileUpgradeLevel == 4){
                projectileUpgradeButton.interactable = false;
        }
    }
}
