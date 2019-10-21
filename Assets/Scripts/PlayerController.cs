using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // aim variables
    [SerializeField] private float horizontalMouseSensitivity = 0.75f;
    [SerializeField] private float verticalMouseSensitivity = 0.75f;

    // movement variables
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    // jump variables
    [SerializeField] private AnimationCurve jumpFalloff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private float jumps = 0f;
    [SerializeField] private KeyCode jumpKey;

    private CharacterController charController;

    private void Start()
    {
        // get that character controller. get it good
        charController = GetComponent<CharacterController>();

        // lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // call a bunch of bullshit right below this
        PlayerMovement();
        MouseLook();
    }

    private void PlayerMovement()
    {
        // this is where the movement magic happens

        //declare variables for future use
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;


        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

        JumpInput();
    }

    private void MouseLook()
    {
        // adjust camera
        float deltaMouseHorizontal = Input.GetAxis("Mouse X") * horizontalMouseSensitivity;
        float newCameraRotY = transform.eulerAngles.y + deltaMouseHorizontal;

        transform.eulerAngles = new Vector3(0, newCameraRotY, 0);

        // unlock cursor if needed
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && jumps < 2)
        {
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        jumps++;
        
        do
        {
            float jumpForce = jumpFalloff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        }
        while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        jumps = 0;
    }
}
