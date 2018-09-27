using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bulletPrefab;
    public string ttag = "Enemy";
    public Transform target;
    public float targetdistance = 5.0f;
    public float dist;
    public float fireDelay;
    private float Distance;
    Transform Enemy;
    float cooldownTimer = 0;
	// Use this for initialization
	void Start () {
        InvokeRepeating("GetClosestEnemy", 0, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
            Enemy = target;
            if (Enemy == null) return;

            Distance = Vector2.Distance(target.position, transform.position);
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

    void GetClosestEnemy()
    {
        GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag(ttag);
        float closestDistSqr = Mathf.Infinity;
        Transform closestEnemy = null;
        foreach (GameObject taggedEnemy in taggedEnemys)
        {
            Vector3 objectPos = taggedEnemy.transform.position;
            dist = Vector2.Distance(objectPos, transform.position);

            if (dist < targetdistance)
            {
                if (dist < closestDistSqr)
                {
                    closestDistSqr = dist;
                    closestEnemy = taggedEnemy.transform;
                }
            }
        }
        target = closestEnemy;
    }
}
