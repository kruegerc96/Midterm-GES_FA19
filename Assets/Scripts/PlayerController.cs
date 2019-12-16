﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // THIS CODE AIDED BY SCRIPT FROM THE UNITY DOCUMENTATION BECAUSE I GOT DESPERATE (https://docs.unity3d.com/ScriptReference/CharacterController.Move.html)

    // variables
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private float sprintMultiplier = 1f;
    private int currentJumps = 0;
    private int maxJumps = 2;

    CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            //reset double jump
            currentJumps = 0;

            //update Vector3 while player is grounded
            moveDirection = (Input.GetAxis("Vertical") * transform.forward * sprintMultiplier + Input.GetAxis("Horizontal") * transform.right) * movementSpeed;
        }

        // sprint if sprint button is pushed and player is moving forward
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0.1)
        {
            sprintMultiplier = 1.75f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprintMultiplier = 1f;
        }

        // jump
        if (Input.GetButtonDown("Jump") && currentJumps < maxJumps)
        {
            //allow change of direction during double jump
            moveDirection = (Input.GetAxis("Vertical") * transform.forward * sprintMultiplier + Input.GetAxis("Horizontal") * transform.right) * movementSpeed;

            currentJumps++;
            moveDirection.y = jumpForce;
        }
        if (Input.GetButtonDown("Jump") && currentJumps == 2)
        {
            AkSoundEngine.PostEvent("PlayJet", gameObject);
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below when the moveDirection is multiplied by deltaTime). This is because gravity should be applied as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
