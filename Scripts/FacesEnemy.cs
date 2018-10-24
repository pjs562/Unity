using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesEnemy : MonoBehaviour {

    public string ttag = "Enemy";
    public Transform target;
    public float targetdistance = 40.0f;
    public float dist;
    GameObject Player;
    public float rotSpeed = 90f;
    Transform Enemy;
    public GameObject finder;
    public void Start()
    {
        InvokeRepeating("GetClosestEnemy", 0, 0.5f);
        Player = GameObject.FindWithTag("Player");
        finder = GameObject.Find("finder");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =Player.transform.position;
        Enemy = target;

        if (Enemy == null)
        {
            finder.SetActive(false);
            return;
        }
        else if (Vector2.Distance(Enemy.position, transform.position) > 3.5) finder.SetActive(true);
        else {
            finder.SetActive(false);
            return;
        }
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

