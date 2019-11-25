﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;

    public void Look() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");

        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);

        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;

        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }
}
