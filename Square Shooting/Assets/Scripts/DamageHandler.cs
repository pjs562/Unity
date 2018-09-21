using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

    public int health;

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");

        health--;
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
