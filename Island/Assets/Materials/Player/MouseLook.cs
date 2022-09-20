using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public Transform playerBody, Hand, FlashLight;
    public static float mouseSensitivity = 200f, sens = 200f;
    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        /*if(Menu.Opened == true){
            Cursor.lockState = CursorLockMode.None;
        }
        if(Menu.Opened == false){
            Cursor.lockState = CursorLockMode.Locked;
        }*/

        float MouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 60f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Hand.localRotation = Quaternion.Euler(xRotation + 90f, -90f, -66f);
        FlashLight.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //Hand.Rotate(-MouseY * new Vector3(0, 1, 0));
        playerBody.Rotate(Vector3.up * MouseX);
    }
}
