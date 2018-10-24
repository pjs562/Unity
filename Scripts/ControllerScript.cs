using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerScript : MonoBehaviour {

    public FloatingJoystick joystick;//조이스틱 스크립트
    public float MoveSpeed;//플레이어의 이동속도
    public float h;
    public float v;

    // Update is called once per frame
    private void Update()
    {
        h = joystick.Horizontal;
        v = joystick.Vertical;
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
