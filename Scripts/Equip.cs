using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Equip : MonoBehaviour, IDropHandler
{
    private Inventory2 inventory2;
    public int i;

    private void Start()
    {
        inventory2 = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory2>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory2.isfull[i] = false;
        }
        else
        {
            inventory2.isfull[i] = true;
        }

    }
    // Use this for initialization
    public GameObject Item
    {
        get
        {
            return transform.childCount > 0 ? transform.GetChild(0).gameObject : null;
        }
    }
        
    public void OnDrop(PointerEventData eventData)
    {
        if (!Item)
        {
            DragHandler2.itemBeingDragged.transform.SetParent(transform);

        }
    }

}