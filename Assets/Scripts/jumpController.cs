using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpController : MonoBehaviour
{
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
    }

    private void Update()
    {
        // call a bunch of bullshit right below this
        JumpInput();
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && jumps < 2)
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
