using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;
		if(cooldownTimer <= 0)
        {
            //Shoot!
            cooldownTimer = fireDelay;
        }
	}
}
