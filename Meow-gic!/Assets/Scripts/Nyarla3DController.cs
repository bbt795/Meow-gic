using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Nyarla3DController : MonoBehaviour
{

    public Rigidbody myRig; //rigidbody
    public Animator myAnim;
    public Vector2 lastDirection;
    public NPC villager;
    public ShopKeepers shopKeeper;
    public bool playerCanMove = true;
    [SerializeField] GameObject interactionPanel;
    public float speed = 10.0f;
    // Start is called before the first frame update
    public void onMove(InputAction.CallbackContext ev){
        if(ev.performed)
        {
            lastDirection = ev.ReadValue<Vector2>();
        }
        if(ev.canceled)
        {
            lastDirection = Vector2.zero;
            myAnim.SetInteger("DIR", 0);
        }
    }
    void Start()
    {
        myRig = this.gameObject.GetComponent<Rigidbody>();
        myAnim = this.GetComponent<Animator>();
        if(myRig == null){
            throw new System.Exception("Player controller needs rigidbody!");
        }
    }

    public void ProgressDialogue(){
        if(villager.currentLine == 0){
            villager.ShowDialogue();
            villager.currentLine++;
        }
        else if (villager.currentLine < villager.dialogueSet.dialogue.Length)
        {
            villager.UpdateDialogue();
            villager.currentLine++;
        }
        else
        {
            Debug.Log(villager.currentLine);
            villager.EndDialogue();
            myRig.isKinematic = false;
            playerCanMove = true;
        }
    }
    public void OpenShop(){
        if(!shopKeeper.shopPanel.activeSelf){
            shopKeeper.ShowShop();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D))
        {

            if (myRig != null && playerCanMove)
            {
                myAnim.SetInteger("DIR", 1);

            }

        }
        if(Input.GetKeyDown(KeyCode.E)){
            // NPC villager = interactable.transform.GetComponent<NPC>();
            if(villager != null){
                interactionPanel.SetActive(false);
                myRig.isKinematic = true;
                playerCanMove = false;
                ProgressDialogue();
            }
            else if(shopKeeper != null){
                interactionPanel.SetActive(false);
                myRig.isKinematic = true;
                playerCanMove = false;
                OpenShop();
            }
        }
        if(myRig.isKinematic && shopKeeper!=null && playerCanMove){
            if(!shopKeeper.shopPanel.activeSelf){
                myRig.isKinematic = false;
            }
        }
        if(!playerCanMove){
            interactionPanel.SetActive(false);
        }
        if(playerCanMove){
            myRig.angularVelocity = new Vector3(0, lastDirection.x, 0)*speed; 
            myRig.velocity = transform.forward*speed*lastDirection.y+new Vector3(0,myRig.velocity.y,0);  
        }
        
    }


    private void OnTriggerEnter(Collider other){
        if(other.tag == "NPC"){
            villager = other.gameObject.transform.GetComponent<NPC>();
            interactionPanel.SetActive(true);
        }
        else if(other.tag == "Shopkeeper"){
            shopKeeper = other.gameObject.transform.GetComponent<ShopKeepers>();
            interactionPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(){
        villager = null;
        shopKeeper = null;
        interactionPanel.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if(collision.gameObject.CompareTag("NPC")){
        //     NPC villager = collision.transform.GetComponent<NPC>();
        //     if (villager != null)
        //         {
        //         // Call the function in the object's script.
        //             villager.ShowDialogue();
        //             Debug.Log(villager.name);
        //         }
        // }
        
        if(collision.transform.gameObject.CompareTag("StartCave")) {

            SceneManager.LoadScene("Forest");
        
        }

    }

}
