using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizMouseLook : MonoBehaviour
{
    public float lookSpeed = 3;
    private float rotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation += Input.GetAxis("Mouse X");

        Vector3 currentRotation = transform.eulerAngles;

        currentRotation.y = rotation;

        transform.eulerAngles = currentRotation;
    }
}
