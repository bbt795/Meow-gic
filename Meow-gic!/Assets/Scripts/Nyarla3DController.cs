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
    [SerializeField] GameObject interactionPanel;
    public float speed = 10.0f;
    // Start is called before the first frame update
    public void onMove(InputAction.CallbackContext ev){
        Debug.Log("Inside Callback");
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D))
        {

            if (myRig != null)
            {
                myAnim.SetInteger("DIR", 1);

            }

        }
        if(Input.GetKeyDown(KeyCode.E) && villager != null){
            // NPC villager = interactable.transform.GetComponent<NPC>();
                interactionPanel.SetActive(false);
                ProgressDialogue();
                // if(villager.currentLine == 0){
                //     villager.ShowDialogue();
                // }
                // else if(villager.currentLine < villager.dialogueSet.dialogue.Length){
                //     villager.UpdateDialogue();
                // }
                // else{
                //     villager.EndDialogue();
                // }
        }
        myRig.angularVelocity = new Vector3(0, lastDirection.x, 0)*speed; 
        myRig.velocity = transform.forward*speed*lastDirection.y+new Vector3(0,myRig.velocity.y,0);
    }
    public void ProgressDialogue(){
        if(villager.currentLine == 0){
            villager.ShowDialogue();
        }
        else if (villager.currentLine < villager.dialogueSet.dialogue.Length)
        {
            villager.currentLine++;
            villager.UpdateDialogue();
        }
        else
        {
            villager.EndDialogue();
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "NPC"){
            villager = other.transform.GetComponent<NPC>();
            interactionPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(){
        villager = null;
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
