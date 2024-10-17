using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    // Movement Variables
    public float speed = 6f;

    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    // Ground Check Variables
    private Vector3 velocity;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Mouse Look Variables
    public Transform playerBody;

    public Camera playerCamera;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    private void Start()
    {
        // Lock the cursor to the center of the screen and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Handle player movement
        HandleMovement();

        // Handle player turning based on mouse input
        HandleMouseLook();
    }

    private void HandleMovement()
    {
        // Check if the character is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset the vertical velocity when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get the input from the user (WASD or arrow keys)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Move the character based on input
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Jump logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player body (yaw) based on the horizontal mouse movement
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate the camera (pitch) based on the vertical mouse movement
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation to prevent over-rotation
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}