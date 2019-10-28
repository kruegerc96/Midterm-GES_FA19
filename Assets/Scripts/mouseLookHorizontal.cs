using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLookHorizontal : MonoBehaviour
{
    // aim variables
    [SerializeField] public float horizontalMouseSensitivity = 0.75f;

    private void Start()
    {
    }

    void Update()
    {
        // adjust body direction
        float deltaMouseHorizontal = Input.GetAxis("Mouse X") * horizontalMouseSensitivity;
        float newBodyRotY = transform.eulerAngles.y + deltaMouseHorizontal;

        transform.eulerAngles = new Vector3(0, newBodyRotY, 0);
    }
}
