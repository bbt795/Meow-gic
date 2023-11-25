using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    public int strength = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other){
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetStrength()
    {

        return strength;

    }

}
