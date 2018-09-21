using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float maxSpeed = 3.5f;
    float rotSpeed = 90f;
	// Use this for initializations
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Rotate the ship

        //Grab our rotation quaternion
        Quaternion rot = transform.rotation;

        //Grab the Z eular angle
        float z =rot.eulerAngles.z;

        //Change the Z angle based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        //Recreate the quternion
        rot = Quaternion.Euler(0, 0, z);

        // Feed the quaternion into out rotation
        transform.rotation = rot;

        //Move the ship
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;
        transform.position = pos;
	}
}
