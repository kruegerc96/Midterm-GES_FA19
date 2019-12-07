using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;

    private void Start()
    {
        // lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //unlock cursor if player presses Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        // Look rotation (UP down is Camera) (Left right is Transform rotation)
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.y += Input.GetAxis("Mouse X");

        rotation.x = Mathf.Clamp(rotation.x, -30f, 30f);

        transform.eulerAngles = new Vector3(rotation.x, rotation.y, 0) * lookSpeed;
    }
}
