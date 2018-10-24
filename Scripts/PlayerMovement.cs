using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initializations
    public float MoveSpeed;//플레이어의 이동속도

    private float h;
    private float v;
    // Use this for initialization


    // Update is called once per frame
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {

        Vector3 pos = transform.position;
        pos.y += v * MoveSpeed * Time.deltaTime;
        pos.x += h * MoveSpeed * Time.deltaTime;
        if (pos.y > 40)
        {
            pos.y = 40;
        }
        else if (pos.y < -40)
        {
            pos.y = -40;
        }
        else { }
        if (pos.x > 40)
        {
            pos.x = 40;
        }
        else if (pos.x < -40)
        {
            pos.x = -40;
        }
        else { }
        transform.position = pos;
    }
}
