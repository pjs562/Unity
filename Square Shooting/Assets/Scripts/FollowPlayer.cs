using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public float rotSpeed = 90f;
    public float maxSpeed;
    Transform player;
    private float Distance;

    // Update is called once per frame
    void Update () {

            GameObject go = GameObject.Find("Player");
            if (go != null)
            {
                Distance = Vector2.Distance(go.transform.position, transform.position);
                if (Distance < 5 && Distance > 0.5)
                {
                    player = go.transform;
                    Vector3 pos = transform.position;

                    Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

                    pos += transform.rotation * velocity;

                    transform.position = pos;

            }
                else{
                    player = null;
                    return;
                }
            }


        if (player == null)
            return;
        Vector2 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }


}
