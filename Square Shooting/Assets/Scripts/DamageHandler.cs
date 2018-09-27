using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    public int health = 1;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger!");
        if (other.CompareTag("Respawn"))
        {
            Debug.Log("GetItem!");
        }
        else { health--; }
    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            Die();
        }
	}

    void Die()
    {
        Destroy(gameObject);
    }
}
