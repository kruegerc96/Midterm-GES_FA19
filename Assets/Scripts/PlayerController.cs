using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement variables
    [SerializeField] private float speed;
    [SerializeField] private float sprintMultiplier;
    private bool isSprinting;

    // aim variables
    [SerializeField] private float horizontalMouseSensitivity;
    [SerializeField] private float verticalMouseSensitivity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // movement
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        // sprint
        if (Input.GetKeyDown("LeftShift"))
        {
            speed = speed * sprintMultiplier;
        }

        // unlock cursor if needed
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
