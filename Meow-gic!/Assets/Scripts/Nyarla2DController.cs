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
    public float speed = 5.0f;
    public float health = 5;
    public float maxHealth;
    public float strength;
    public float wealth;
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
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                CreateStarAttack(Vector2.up);  
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                CreateStarAttack(Vector2.left);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)){
                CreateStarAttack(Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow)){
                CreateStarAttack(Vector2.down);
            }
        }
    }
    void CreateStarAttack(Vector2 direction){
        Vector3 spawnPosition = transform.position + new Vector3(direction.x, direction.y, 0);
        GameObject temp = GameObject.Instantiate(starAttack, spawnPosition, Quaternion.identity);
        temp.GetComponent<Rigidbody2D>().velocity = direction*speed*1.2f;
    }
    void Start()
    {
        myAnim = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myRig = this.GetComponent<Rigidbody2D>();
        maxHealth = health;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Gold"){
            Coins otherObject = other.gameObject.GetComponent<Coins>();
            wealth += otherObject.value;
            Debug.Log(wealth);
            Destroy(otherObject.gameObject);
        }
        if(other.tag == "Health"){
            HealthPotions otherObject = other.gameObject.GetComponent<HealthPotions>();
            health = maxHealth;
            Debug.Log(health);
            Destroy(otherObject.gameObject);
        }
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
