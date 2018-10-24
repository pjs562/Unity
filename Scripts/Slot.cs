using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    private Inventory inventory;
    public int i;
    private GameObject deleteSound;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        deleteSound = GameObject.Find("deleteSound");
    }

    private void Update()
    {
        if(transform.childCount <= 0){
            inventory.isFull[i] = false;
        }
    }
    public void DropItem(){
        foreach (Transform child in transform){
            GameObject DeleteSound = Instantiate(deleteSound);
            Destroy(DeleteSound, 1);
            Destroy(child.gameObject);
        }
    }
}
