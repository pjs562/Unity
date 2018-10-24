using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageHandlerHeart : MonoBehaviour {
    public int health = 10;
    private GameObject explode;
    private GameObject expsound;
    public Slider hpSlider;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            return;
        }
        else { health--; }
    }

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Heart");
        explode = GameObject.Find("explode");
        expsound = GameObject.Find("expSound");
        hpSlider.maxValue = health;
        Invoke("NaturalHealing", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = health;
        if (health <= 0)
        {
            Die();
        }
        else return;
    }

    private void Die()
    {
        GameObject Explode = Instantiate(explode, transform.position, explode.transform.rotation);
        GameObject ExpSound = Instantiate(expsound);
        Destroy(Explode, 1);
        Destroy(ExpSound, 1);
        SceneManager.LoadScene("Menu");
        Destroy(gameObject);
    }

    void NaturalHealing()
    {
        if (health < 10)
        {
            ++health;
        }
        else { health = 10; }
    }
}
