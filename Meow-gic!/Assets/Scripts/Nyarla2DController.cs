using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Nyarla2DController : Entity
{
    public GameObject myTarget;
    public GameObject[] myTargets;
    public Animator myAnim;
    public SpriteRenderer myRenderer;
    public Rigidbody2D myRig;
    public float teleportUpDown = 11f; 
    public float teleportLeftRight = 16f;
    public float speed = 5.0f;
    public float health = 10f;
    public float maxHealth;
    public int strength = 1;
    public GameObject healthDisplay;
    public TextMeshProUGUI healthDisplayText;
    public GameObject goldDisplay;
    public TextMeshProUGUI goldDisplayText;
    public GameObject gameManager;
    public GameObject starAttack;
    public Vector2 lastDirection;
    public string villageScene;
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
        temp.GetComponent<Projectile>().strength = strength;
        temp.GetComponent<Rigidbody2D>().velocity = direction*speed*2f;
    }
    void Start()
    {
        myAnim = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myRig = this.GetComponent<Rigidbody2D>();
        maxHealth = health;
        healthDisplayText = healthDisplay.GetComponent<TextMeshProUGUI>();
        goldDisplayText = goldDisplay.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Gold"){
            Coins otherObject = other.gameObject.GetComponent<Coins>();
            gameManager.GetComponent<DoNotDestroy>().gold += otherObject.value;
            Debug.Log(gameManager.GetComponent<DoNotDestroy>().gold);
            Destroy(otherObject.gameObject);
        }
        if(other.tag == "Health"){
            HealthPotions otherObject = other.gameObject.GetComponent<HealthPotions>();
            health = maxHealth;
            Debug.Log(health);
            Destroy(otherObject.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.name == "DoorTop"){
            myRig.transform.position += new Vector3(0f, teleportUpDown, 0f);
        }
        if(other.gameObject.name == "DoorLeft"){
            myRig.transform.position += new Vector3(-teleportLeftRight, 0f, 0f);
        }
        if(other.gameObject.name == "DoorRight"){
            myRig.transform.position += new Vector3(teleportLeftRight, 0f, 0f);
        }
        if(other.gameObject.name == "DoorBottom"){
            myRig.transform.position += new Vector3(0f, -teleportUpDown, 0f);
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
        if(health <= 0 && gameManager.GetComponent<DoNotDestroy>().lives != 0){
            gameManager.GetComponent<DoNotDestroy>().lives -= 1;
            SceneManager.LoadScene(villageScene);
            //Change scene to village, transfer information about lives and gold
        }
        else if (health <= 0 && gameManager.GetComponent<DoNotDestroy>().lives <= 0){
            //End game/bring player back to home screen/exit game
        }
        
        var velocity = new Vector2(lastDirection.x, lastDirection.y).normalized * speed;
        myRig.velocity = new Vector2(velocity.x, velocity.y);
        healthDisplayText.text = "Health: " + health;
        goldDisplayText.text = "Gold: " + gameManager.GetComponent<DoNotDestroy>().gold;
    }
}
