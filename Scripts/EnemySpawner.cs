using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemyPrefab;

    public float spawnDistance = 3f;
    private float enemyRate;
    float nextEnemy = 25;
    float n;
    int i;
    float timer;
    Vector3 offset;
    // Use this for initialization
    void Start () {
        timer = 0.0f;
        enemyRate = 13;
    }
	
	// Update is called once per frame
	void Update () {
        nextEnemy -= Time.deltaTime;
        timer += Time.deltaTime;
        if(nextEnemy <= 0){
            nextEnemy = enemyRate;
            
            offset = Random.onUnitSphere;
            offset.z = 0;
            n = Random.Range(2, 11);
            offset = offset.normalized * spawnDistance * n;
            if(timer < 180)
            { 
                i = Random.Range(0, 6); 
            }else if (timer >= 180 && timer < 360)
            {
                i = Random.Range(6, 11);
            }else if ( timer >= 360 && timer < 540)
            {
                i = Random.Range(11, 16);
            }else if ( timer >= 540 && timer < 720)
            {
                i = Random.Range(16, 21);
            }else if ( timer >= 720 && timer < 900)
            {
                i = Random.Range(21, 26);
            }else if ( timer >= 900 && timer < 1080)
            {
                i = Random.Range(26, 31);
            }
            else if ( timer >= 1080 && timer < 1260)
            {
                i = Random.Range(31, 36);
            }
            else if ( timer >= 1260 && timer < 1440)
            {
                i = Random.Range(36, 41);
            }
            else if ( timer >= 1440 && timer < 1620)
            {
                i = Random.Range(41, 46);
            }
            else if ( timer >= 1620 && timer < 1800)
            {
                i = Random.Range(46, 52);
            }
            else if (timer >= 1800) 
            {
                Instantiate(enemyPrefab[53], transform.position + offset, Quaternion.identity);
                Destroy(gameObject);
            }
            Instantiate(enemyPrefab[i], transform.position + offset, Quaternion.identity);
        }
	}
}
