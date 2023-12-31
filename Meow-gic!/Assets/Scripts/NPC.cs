using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public DialogueAsset dialogueSet;
    public string name;
    public int currentLine = 0;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public GameObject dialoguePanel;
    // Start is called before the first frame update
    public void ShowDialogue()
    {
        currentLine = 0;
        nameText.text = name;
        dialogueText.text = dialogueSet.dialogue[currentLine];
        dialoguePanel.SetActive(true);

    }

    public void UpdateDialogue(){
        dialogueText.text = dialogueSet.dialogue[currentLine];
    }
    public void EndDialogue()
    {
        currentLine = 0;
        nameText.text = null;
        dialogueText.text = null;
        dialoguePanel.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
