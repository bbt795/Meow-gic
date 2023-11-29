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
    public int strength = 1;
    public Vector2 presetDirection;
    private Vector2 followDirection;
    public float distance;
    public bool followPlayer = false;
    public GameObject gold;
    public GameObject potion;
    public GameObject playerAttack;
    public float fireRate = 2f;          // Firing rate in shots per second
    private float timeSinceLastFire = 0f;

    void CreatePlayerAttack(Vector2 direction){

        Vector2 spawnPosition = (Vector2)transform.position + direction.normalized * 1.5f;
        // Instantiate the projectile
        GameObject projectile = Instantiate(playerAttack, spawnPosition, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        // Apply force to the projectile in the direction of the player
        projectile.GetComponent<Projectile>().strength = strength;
        projectileRb.velocity = direction * speed *2.5f;
        // temp.GetComponent<Projectile>().strength = strength;
        // temp.GetComponent<Rigidbody2D>().velocity = direction*speed*2f;
    }

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

        if (other.gameObject.CompareTag("Attack"))
        {


            Projectile otherObject = other.gameObject.GetComponent<Projectile>();
            health -= otherObject.GetStrength();

        } 

        if(other.gameObject.CompareTag("Player")){
            Nyarla2DController otherObject = other.gameObject.GetComponent<Nyarla2DController>();
            otherObject.health -= strength;
        }
    }

    void CreateCoins(){
        GameObject temp = GameObject.Instantiate(gold, transform.position, Quaternion.identity);
        temp.GetComponent<Coins>().value = Mathf.Ceil(maxHealth/2);
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
        if (gameObject.name == "Tree" && distance < 12f){
            Vector2 direction = player.transform.position - transform.position;
            timeSinceLastFire += Time.deltaTime;
            
            // Check if enough time has passed to fire again
            if (timeSinceLastFire >= 1f / fireRate)
            {
                // Fire the projectile
                CreatePlayerAttack(direction.normalized);

                // Reset the firing timer
                timeSinceLastFire = 0f;
            }
            
            
        }
        if(health<=0)
        {
            CreateCoins();
            CreatePotions();
            Destroy(this.gameObject);
        }
    }
}
