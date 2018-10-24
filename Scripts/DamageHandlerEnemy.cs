﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandlerEnemy : MonoBehaviour {
    public GameObject SpawnItem;
    public int health = 1;
    private GameObject explode;
    private GameObject expsound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            return;
        }
        else if (other.CompareTag("RedBullet")) { health--; }
        else if (other.CompareTag("PuppleBullet")) { health -= 4; }
        else if (other.CompareTag("BlueBullet")) { health -= 20; }
        else if (other.CompareTag("GreenBullet")) { health -= 100; }
        else { health--; }
    }

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Heart");
        explode = GameObject.Find("explode");
        expsound = GameObject.Find("expSound");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        else if (GameObject.Find("Heart") == null) { Die(); }
        else return;
    }

    void Die()
    {
        GameObject Explode = Instantiate(explode, transform.position, explode.transform.rotation);
        GameObject ExpSound = Instantiate(expsound);
        Destroy(Explode, 1);
        Destroy(ExpSound, 1);
        Instantiate(SpawnItem, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }
}
