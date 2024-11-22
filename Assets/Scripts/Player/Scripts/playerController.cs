using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    private InputAction move;
    private Vector2 inputVector;
    public float speed = 5f;
    public float rotationSpeed = 100f;
    public float fireRate = 0.25f;
    public int score = 0;
    private float nextFire;
    public GameObject shot;

    private InputAction movement;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        // Enable the movement input action
        movement = playerInput.Player.Move;
        movement.Enable();

        // Enable the fire input action and bind the DoFire method to it
        playerInput.Player.Fire.performed += DoFire;
        playerInput.Player.Fire.Enable();
    }

    private void OnDisable()
    {
        // Disable the movement and fire input actions
        movement.Disable();
        playerInput.Player.Fire.Disable();
    }

    private void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();

        // Get the shot prefab from Resources
        shot = Resources.Load<GameObject>("Shot");

        // Initialize movement input action
        move = playerInput.Player.Move;
        move.Enable();
    }

    private void FixedUpdate()
    {
        // Handle player movement based on input values
        inputVector = movement.ReadValue<Vector2>();
        float moveInput = inputVector.y; // W/S for forward/backward
        float rotationInput = inputVector.x; // A/D for rotation

        // Apply rotation
        if (rotationInput != 0)
        {
            float rotation = rotationInput * rotationSpeed * Time.fixedDeltaTime;
            transform.Rotate(0, rotation, 0); // Rotate player on Y-axis
        }

        // Apply forward movement
        if (moveInput != 0)
        {
            Vector3 forwardMovement = transform.forward * moveInput * speed;
            rb.velocity = forwardMovement;
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

    // Handle firing a shot when the Fire input action is triggered
    private void DoFire(InputAction.CallbackContext context)
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; // Apply fire rate cooldown

            // Instantiate the shot and set the player's position and rotation
            GameObject newShot = Instantiate(shot, transform.position, transform.rotation);
            newShot.GetComponent<ShotScript>().SetOrigin(gameObject); // Set this game object as the shot's origin
        }
    }
}
