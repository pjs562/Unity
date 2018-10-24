using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject bulletPrefab;

    private float fireDelay = 0.5f;

    private float Distance;

    public float distance = 4;

    private float cooldownTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("Player");

        if (go != null)
        {
            Distance = Vector2.Distance(go.transform.position, transform.position);

            if (Distance < distance)
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
