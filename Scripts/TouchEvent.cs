using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvent : MonoBehaviour {
    Vector2 WorldPoint;
    private Camera cam;
    public GameObject SpawnItem;
    private GameObject UnequipSound;
    private void Start()
    {
        cam = Camera.main;
        UnequipSound = GameObject.Find("UnequiptSound");
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                WorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(transform.position, WorldPoint) < 0.3)
                {
                    Destroy(gameObject);
                    Instantiate(SpawnItem, transform.position, transform.rotation);
                    GameObject unequipSound = Instantiate(UnequipSound);
                    Destroy(unequipSound, 1);
                }
            }
        }
        else
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                WorldPoint = cam.ScreenToWorldPoint(touch.position);
                if (Vector2.Distance(transform.position, WorldPoint) < 0.3)
                {
                    Destroy(gameObject);
                    Instantiate(SpawnItem, transform.position, transform.rotation);
                    GameObject unequipSound = Instantiate(UnequipSound);
                    Destroy(unequipSound, 1);
                }
            }
        }
    }
}
