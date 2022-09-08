using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControls : MonoBehaviour {

    public static bool islocked;

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        islocked = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (islocked)   {

        Cursor.visible = false;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        }
        else if (!islocked)
        {
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.F1) && !islocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            islocked = true;
        }
        else if (Input.GetKeyDown(KeyCode.F1) && islocked)
        {
            Cursor.lockState = CursorLockMode.None;
            islocked = false;
        }
    }
}

