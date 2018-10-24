using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public FloatingJoystick joystick;

    private void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up  * joystick.Vertical);

        if (moveVector != Vector3.zero)
        { 
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }
    }
}
