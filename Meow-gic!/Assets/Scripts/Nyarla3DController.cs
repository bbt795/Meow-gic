using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Nyarla3DController : MonoBehaviour
{

    public Rigidbody myRig; //rigidbody
    public Animator myAnim;
    public Vector2 lastDirection;
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
        myRig.angularVelocity = new Vector3(0, lastDirection.x, 0)*speed; 
        myRig.velocity = transform.forward*speed*lastDirection.y+new Vector3(0,myRig.velocity.y,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.transform.gameObject.CompareTag("StartCave")) {
        
            
        
        }

    }

}
