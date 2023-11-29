using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    public int strength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(gameObject.CompareTag("Projectile") && other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<Nyarla2DController>().health -= 1;
        }
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
