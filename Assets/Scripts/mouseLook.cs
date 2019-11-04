using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    // aim variables
    [SerializeField] public float horizontalMouseSensitivity = 0.75f;
    [SerializeField] public float verticalMouseSensitivity = 0.75f;

    private void Start()
    {
    }

    void Update()
    {
        float deltaMouseHorizontal = Input.GetAxis("Mouse X") * horizontalMouseSensitivity;
        float deltaMouseVertical = Input.GetAxis("Mouse Y") * verticalMouseSensitivity;
        float newCameraRotX = transform.eulerAngles.x - deltaMouseVertical;
        float newBodyRotY = transform.eulerAngles.y + deltaMouseHorizontal;

        transform.eulerAngles = new Vector3(newCameraRotX, newBodyRotY, 0);
    }
}
