using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform playerBody;


    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // this will hide our cursor
    }

    // Update is called once per frame
    void Update()
    {
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;   
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; 
      
      xRotation -= mouseY; // decrease x rotation every frame depending on mouseY
      xRotation = Mathf.Clamp(xRotation, -90f, 90f); // making sure we dont over rotate player view


      transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // (x,y,z)
      playerBody.Rotate(Vector3.up * mouseX);        
    }
}
