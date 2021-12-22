using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0,10,-10);
    }

    void LateUpdate()
    {
        transform.rotation = target.rotation;
        //Vector3 desirePosition;
        if (transform.eulerAngles.y == 270)
            offset = new Vector3(10, 10, 0);
        else if (transform.eulerAngles.y == 180)
            offset = new Vector3(0, 10, 10);
        else if (transform.eulerAngles.y == 90)
            offset = new Vector3(-10, 10, 0);
        else
            offset = new Vector3(0, 10, -10);

        transform.position = target.position + offset;
        // n = Vector3.Lerp(transform.position,desirePosition,smoothSpeed);

    }
}
