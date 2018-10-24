using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SecondSlot : MonoBehaviour, IDropHandler
{

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
            if (DragHandler2.itemBeingDragged != null)
            {
                DragHandler2.itemBeingDragged.transform.SetParent(transform);
            }else if(DragHandler3.itemBeingDragged != null)
            {
                DragHandler3.itemBeingDragged.transform.SetParent(transform);
            }
        }
    }
}
