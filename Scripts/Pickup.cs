using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;
    private GameObject pickup;
	// Use this for initialization
	void Start () {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        pickup = GameObject.Find("PickUpSound");
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i]==false){
                    inventory.isFull[i] = true;
                    GameObject Pickup = Instantiate(pickup);
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(Pickup, 1);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
