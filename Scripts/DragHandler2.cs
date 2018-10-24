using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragHandler2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    public GameObject item;
    private GameObject EquipSound;
    private GameObject[] selected;
    private int n;
    private int ChildCount;
    public GameObject ThreeDirection;
    private GameObject[] Elements;
    private GameObject[] Tops;
    private void Start()
    {
        EquipSound = GameObject.Find("EquipSound");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Elements = GameObject.FindGameObjectsWithTag("Element");
        Tops = GameObject.FindGameObjectsWithTag("Top");
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        for (int i = 0; i < Elements.Length; i++){
            if (Elements[i].transform.childCount <= 0)
                Elements[i].GetComponent<SpriteRenderer>().enabled = true;
        }

        for (int i = 0; i < Tops.Length; i++)
        {
            if (Tops[i].transform.childCount <= 0)
                Tops[i].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        itemBeingDragged = null; 
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        n = GameObject.FindWithTag("MainCamera").GetComponent<objectSelect>().hits.Length;
        selected = new GameObject[n];
        ChildCount = 0;

        for (int i = 0; i < n; i++)
        {
            selected[i] = GameObject.FindWithTag("MainCamera").GetComponent<objectSelect>().targets[i];
            if (selected[i] != null)
            {
                if (selected[i].transform.childCount > 0)
                {
                    ChildCount++;
                    break;
                }
            }
        }
        if (ChildCount == 0)
        {
            for (int i = 0; i < n; i++)
            {
                if (selected[i] != null)
                {
                        Instantiate(item, selected[i].transform.position, selected[i].transform.rotation).transform.SetParent(selected[i].transform);
                        Instantiate(ThreeDirection, selected[i].transform.position, selected[i].transform.rotation).transform.SetParent(selected[i].transform.GetChild(0));
                        GameObject equipSound = Instantiate(EquipSound);
                        Destroy(equipSound, 1);
                        Destroy(gameObject);
                        break;
                }
            }
        }
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
        for (int i = 0; i < Elements.Length; i++)
        {
            Elements[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        for (int i = 0; i < Tops.Length; i++)
        {
            Tops[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

}
