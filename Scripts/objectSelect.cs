using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSelect : MonoBehaviour {
    public GameObject[] targets = new GameObject[5];
    public RaycastHit2D[] hits;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.isEditor)
        {
            if (Input.GetMouseButton(0))
            {
                CastRay();
            }
        }
        else
        { 
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                CastRay();
            } 
        }
    }

    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {

        targets[0] = null;
        targets[1] = null;
        targets[2] = null;
        targets[3] = null;
        targets[4] = null;
        targets[5] = null;
        targets[6] = null;
        targets[7] = null;
        targets[8] = null;
        targets[9] = null;
        targets[10] = null;
        targets[11] = null;
        targets[12] = null;
        targets[13] = null;
        targets[14] = null;
        targets[15] = null;
        targets[16] = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        hits = Physics2D.RaycastAll(pos, Vector2.zero, 0f,1<<12);
        for (int i = 0; i < hits.Length; i++)
        {
            targets[i] = hits[i].collider.gameObject;
        }
       
    }
}
