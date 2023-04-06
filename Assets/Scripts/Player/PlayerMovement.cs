using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [Header("Jumping")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private int availableJumps;
    private int currentAvailableJumps;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector3 input;
    private bool grounded;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        currentAvailableJumps = availableJumps;
    }

    private void Update()
    {
        //Check if grounded
        grounded = controller.isGrounded;
        if (grounded)
            currentAvailableJumps = availableJumps;

        //Apply gravity
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        if (grounded && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        //Camera Relative Movement
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        Vector3 directionalMovement = cameraForward * input.z + cameraRight * input.x;

        //Apply final movement
        Vector3 finalVelocity = directionalMovement * moveSpeed + playerVelocity;
        controller.Move(finalVelocity * Time.deltaTime);
    }


    //Input events
    private void OnJump()
    {
        if (currentAvailableJumps <= 0) return;
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity.y);
        currentAvailableJumps--;
    }
    private void OnMove(InputValue value)
    {
        input = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
        input.Normalize();
    }
}