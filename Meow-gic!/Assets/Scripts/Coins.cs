using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Coins : MonoBehaviour
{
    public float value;
    public Rigidbody2D myRig;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        myRig = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
