﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    // aim variables
    [SerializeField] private float horizontalMouseSensitivity = 0.75f;
    [SerializeField] private float verticalMouseSensitivity = 0.75f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // adjust camera
        float deltaMouseVertical = Input.GetAxis("Mouse Y") * verticalMouseSensitivity;
        float newCameraRotX = transform.eulerAngles.x - deltaMouseVertical;

        transform.eulerAngles = new Vector3(newCameraRotX, 0, 0);

        // unlock cursor if needed
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
