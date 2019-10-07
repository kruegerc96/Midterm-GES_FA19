using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement variables
    [SerializeField] private float speed = 10f;
    [SerializeField] private float sprintMultiplier = 1.5f;
    private float horizontalInput;
    private float forwardInput;

    // aim variables
    [SerializeField] private float horizontalMouseSensitivity = 0.75f;
    [SerializeField] private float verticalMouseSensitivity = 0.75f;


    void Start()
    {
        
    }

    void Update()
    {
        // move forward
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // mouse look
        float deltaMouseHorizontal = Input.GetAxis("Mouse X") * horizontalMouseSensitivity;
        float deltaMouseVertical = Input.GetAxis("Mouse Y") * verticalMouseSensitivity;
        float newCameraRotY = transform.eulerAngles.y + deltaMouseHorizontal;
        float newCameraRotX = transform.eulerAngles.x - deltaMouseVertical;

        transform.eulerAngles = new Vector3(newCameraRotX, newCameraRotY, 0);
    }
}
