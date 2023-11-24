using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Animator myAnim;
    public SpriteRenderer myRenderer;
    public Rigidbody2D myRig;
    public float speed = 5.0f;
    public float health;
    public float strength;
    public Vector2 presetDirection;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = this.GetComponent<Animator>();
        myRenderer = this.GetComponent<SpriteRenderer>();
        myRig = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Wall")){
            presetDirection *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = new Vector2(presetDirection.x, presetDirection.y).normalized * speed;
        myRig.velocity = new Vector2(velocity.x, velocity.y);
    }
}
