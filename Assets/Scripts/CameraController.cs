using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public bool usingOffsetValues;

    public float rotateSpeed;

    public Transform pivot;

    public float maxCamAngle;
    public float midCamAngle;

    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {
        if (!usingOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Gets mouse's X position and rotates the player.
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //Gets mouse's Y position and rotates the pivot.
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }


        //Limits camera rotation to prevent inverting
        if (pivot.rotation.eulerAngles.x > maxCamAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxCamAngle, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f + midCamAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + midCamAngle, 0, 0);
        }

        //Moves camera based on current position of player and original offset.
        float yAngle = target.eulerAngles.y;
        float xAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.position = target.position - (rotation * offset);

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z); ;
        }
        transform.LookAt(target);
    }
}
