using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerScript : MonoBehaviour {

    public JoyStick joystick;//조이스틱 스크립트
    public float MoveSpeed;//플레이어의 이동속도

    private Vector3 _moveVector;//플레이어 이동벡터
    private Transform _transform;

    public float h;
    public float v;
	// Use this for initialization
	void Start () {
        _transform = transform; // 트랜스폼 캐싱
        _moveVector = Vector3.zero; //플레이어 이동벡터 초기화
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
        transform.position = pos;
    }
}
