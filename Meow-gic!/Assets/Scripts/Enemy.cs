using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Animator myAnim;
    public SpriteRenderer myRenderer;
    public Rigidbody2D myRig;
    public GameObject player;
    public float speed = 4.0f;
    public float health;
    public float strength;
    public Vector2 presetDirection;
    private Vector2 followDirection;
    public float distance;
    public bool followPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myRig = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Wall") && followPlayer == false){
            presetDirection *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, myRig.transform.position);
        var velocity = new Vector2(followDirection.x, followDirection.y).normalized * speed;
        myRig.velocity = new Vector2(velocity.x, velocity.y);
        if(distance < 4f){
            followDirection = (player.transform.position - transform.position).normalized;
            followPlayer = true;
        }
        else{
            followDirection = presetDirection;
            followPlayer = false;
        }
    }
}
