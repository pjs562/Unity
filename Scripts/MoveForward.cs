using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float maxSpeed ;
    Vector3 pos;
    Vector3 velocity;
    private void Start()
    {
        pos = transform.position;
        velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
    }
    // Update is called once per frame
    void Update()
    {
        pos += transform.rotation * velocity;

        transform.position = pos;
    }
}
