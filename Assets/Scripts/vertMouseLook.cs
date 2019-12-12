using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertMouseLook : MonoBehaviour
{
    public float lookSpeed = 3;
    private float rotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //change angle of camera based on player input
        rotation += -Input.GetAxis("Mouse Y");

        Vector3 currentRotation = transform.eulerAngles;

        currentRotation.x = rotation;

        transform.eulerAngles = currentRotation;

        //unlock cursor if player presses Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
