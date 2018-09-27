using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesEnemy : MonoBehaviour {

    public string ttag = "Enemy";
    public Transform target;
    public float targetdistance = 5.0f;
    public float dist;

    public float rotSpeed = 90f;
    Transform Enemy;
    public void Start()
    {
        InvokeRepeating("GetClosestEnemy", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
               Enemy = target;
        

        if (Enemy == null)
            return;
        Vector3 dir = Enemy.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }

    void GetClosestEnemy(){
        GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag(ttag);
        float closestDistSqr = Mathf.Infinity;
        Transform closestEnemy = null;
        foreach(GameObject taggedEnemy in taggedEnemys)
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

