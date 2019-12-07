using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // variables
    [SerializeField] private float movementSpeed;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private float jumpForce;

    private int numberOfJumps = 0;
    private int maxJumps = 2;
    private bool isOnGround = true;

    public Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //reset double jump when player touches the ground
        if (isOnGround = true)
        {
            numberOfJumps = 0;
        }

        PlayerMovement();
        CheckJumpInput();
    }

    private void PlayerMovement()
    {
        //this is where the movement magic happens
        //declare variables for future use

        //CHANGE TO RELATIVE DIRECTION

        float horizInput = Input.GetAxis("Horizontal") * movementSpeed;
        float vertInput = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 currentVelocity = playerRb.velocity;
        currentVelocity.x = horizInput;
        currentVelocity.z = vertInput;
        playerRb.AddRelativeForce(Vector3.forward * movementSpeed);
    }

    private void CheckJumpInput()
    {
        if (Input.GetButton("Jump") && numberOfJumps < maxJumps)
        {
            Jump();
        }
    }

    private void Jump()
    {
        numberOfJumps++;
    }
}
