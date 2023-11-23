using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{   
    public Camera cam;
    public float lookSpeed;
    public float maximumX = 60f;
    public float minimumX = -60f; //these two lines are for locking camera rotation

    private float rotationX = 0f;
    private float rotationY = 0f;
    

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void CameraMove(){
        //get inputs
        rotationX += Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY += Input.GetAxis("Mouse X") * lookSpeed;

        //clamp rotation
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        //apply rotation
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        cam.transform.localEulerAngles = new Vector3(-rotationX, 0, 0);
    }
}
