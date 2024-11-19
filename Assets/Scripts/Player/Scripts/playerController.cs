using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInputActions;
    private InputAction move;
    private Vector2 inputVector;
    public float speed = 5f;
    public float rotationSpeed = 100f;
    public float lives = 3;

    public float fireRate = 0.25f;
    private float nextFire;
    public int score = 0;
    public GameObject shot;

    private void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();

        // Initialize player input actions
        playerInputActions = new PlayerInput();

        // Retrieve the movement input action from the Player Input
        move = playerInputActions.Player.Move;

        // Enable the movement input action
        move.Enable();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            // Cooldown for shooting
            nextFire = Time.time + fireRate;

            // Instantiate a shot
            Instantiate(shot, transform.position, transform.rotation);
        }
    }

    private void FixedUpdate()
    {
        // Get movement input as a Vector2 from the input system
        inputVector = move.ReadValue<Vector2>();

        float moveInput = inputVector.y; // W/S for forward/backward
        float rotationInput = inputVector.x; // A/D for rotation

        // add rotation based on input
        if (rotationInput != 0)
        {
            float rotation = rotationInput * rotationSpeed * Time.fixedDeltaTime;
            transform.Rotate(0, rotation, 0); // Rotate player on Y-axis
        }

        if (moveInput != 0)
        {
            Vector3 forwardMovement = transform.forward * moveInput * speed;
            rb.velocity = forwardMovement; // Move in the player's forward direction
        }

        else
        {
            rb.velocity = Vector3.zero; // Stop movement when no input is given
        }
    }

    public Vector3 GetMovementDirection()
    {
        // Return the normalized movement direction vector scaled by speed
        return transform.forward * inputVector.y * speed;
    }
}
