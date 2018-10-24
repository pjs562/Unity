
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private float rotSpeed = 120f;
    private float maxSpeed = 1.8f;
    Transform player;
    private float Distance;
    private float disM = 6f;
    public float dism = 1;
    private float zAngle;
    Vector3 pos;
    Vector3 velocity;
    GameObject go;
    Vector2 dir;
    Quaternion desiredRot;
    // Update is called once per frame
    void Update () {

            go = GameObject.Find("Player");
        if (go != null)
        {
            Distance = Vector2.Distance(go.transform.position, transform.position);
            if (Distance < disM && Distance > dism)
            {
                player = go.transform;
                pos = transform.position;

                velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

                pos += transform.rotation * velocity;

                transform.position = pos;
                dir = player.position - transform.position;
                dir.Normalize();

                zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

                desiredRot = Quaternion.Euler(0, 0, zAngle);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
            }
            else if (Distance <= 1) { }
            else
            {
                player = null;
                return;
            }
        }
        else { player = null; return; }

    }


}
