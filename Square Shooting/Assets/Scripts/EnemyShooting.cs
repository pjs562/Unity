using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject bulletPrefab;

    public float fireDelay;
    private float Distance;
    float cooldownTimer = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("Player");
        if (go != null)
        {
            Distance = Vector2.Distance(go.transform.position, transform.position);
            if (Distance < 5)
            {
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0)
                {
                    //Shoot!
                    cooldownTimer = fireDelay;

                    Instantiate(bulletPrefab, transform.position, transform.rotation);
                }
            }
        }
    }
}
