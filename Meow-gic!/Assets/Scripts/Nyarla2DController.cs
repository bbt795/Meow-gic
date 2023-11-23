using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Nyarla2DController : Entity
{
    public GameObject myTarget;
    public GameObject[] myTargets;
    public Animator myAnim;
    public SpriteRenderer myRenderer;
    public Rigidbody2D myRig;
    //Entity float speed = 5.0f;
    public Vector2 lastDirection;
    public GameObject starAttack;
    // Start is called before the first frame update
    public void onMove(InputAction.CallbackContext ev)
    {
        //Debug.Log("Inside Callback");
        if (ev.performed)
        {
            lastDirection = ev.ReadValue<Vector2>();
        }
        if (ev.canceled)
        {
            lastDirection = Vector2.zero;
            myAnim.SetInteger("DIR", 0);
        }
    }
    public void onFire(InputAction.CallbackContext ev){
        if(ev.started){
            GameObject temp = GameObject.Instantiate(starAttack, this.transform.position + this.transform.forward*.75f, this.transform.rotation);
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                temp.GetComponent<Rigidbody2D>().velocity = Vector2.up*speed;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                temp.GetComponent<Rigidbody2D>().velocity = Vector2.left*speed;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                temp.GetComponent<Rigidbody2D>().velocity = Vector2.right*speed;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)){
                temp.GetComponent<Rigidbody2D>().velocity = Vector2.down*speed;
            }
            //Instantiate returns a type GameObject
            //temp.GetComponent<Rigidbody2D>().velocity = transform.forward*speed*2.0f; //bullet speed is double player speed
        }
    }
    void Start()
    {
        myAnim = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myRig = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D))
        {

            if (myRenderer != null)
            {
                myAnim.SetInteger("DIR", 1);

            }

        }
        var velocity = new Vector2(lastDirection.x, lastDirection.y).normalized * speed;
        myRig.velocity = new Vector2(velocity.x, velocity.y);
    }
}
