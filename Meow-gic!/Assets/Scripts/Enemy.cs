using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Animator myAnim;
    public SpriteRenderer myRenderer;
    public Rigidbody2D myRig;
    public GameObject player;
    public float speed;
    public float health = 5;
    public float maxHealth;
    public Vector2 presetDirection;
    private Vector2 followDirection;
    public float distance;
    public bool followPlayer = false;
    public GameObject gold;
    public GameObject potion;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myRig = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        maxHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Wall") && followPlayer == false)
        {

            presetDirection *= -1;

        }

        if (other.gameObject.CompareTag("Projectile"))
        {


            Projectile otherObject = other.gameObject.GetComponent<Projectile>();
            health -= otherObject.GetStrength();
            Debug.Log(health);

        } 
    }

    void CreateCoins(){
        GameObject temp = GameObject.Instantiate(gold, transform.position, Quaternion.identity);
        temp.GetComponent<Coins>().value = maxHealth/2;
    } 

    void CreatePotions(){
        int randVal = Random.Range(1, 11);
        if(randVal < maxHealth){
            GameObject temp = GameObject.Instantiate(potion, transform.position, Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, myRig.transform.position);
        var velocity = new Vector2(followDirection.x, followDirection.y).normalized * speed;
        myRig.velocity = new Vector2(velocity.x, velocity.y);

        if(distance < 4f)
        {
            followDirection = (player.transform.position - transform.position).normalized;
            followPlayer = true;
        }
        else
        {
            followDirection = presetDirection;
            followPlayer = false;
        }
        if(health<=0)
        {
            CreateCoins();
            CreatePotions();
            Destroy(this.gameObject);
        }
    }
}
