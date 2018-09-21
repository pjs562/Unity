using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerScript : MonoBehaviour {

    public JoyStick joystick;//조이스틱 스크립트
    public float MoveSpeed;//플레이어의 이동속도

    public float h;
    public float v;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
         h = joystick.GetHorizontalValue();
         v = joystick.GetVerticalValue();
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
        if (pos.y > 20)
        {
            pos.y = 20;
        }
        else if (pos.y < -20)
        {
            pos.y = -20;
        }
        else { }
        if (pos.x > 20)
        {
            pos.x = 20;
        }
        else if (pos.x < -20)
        {
            pos.x = -20;
        }
        else { }
        transform.position = pos;
    }
}
