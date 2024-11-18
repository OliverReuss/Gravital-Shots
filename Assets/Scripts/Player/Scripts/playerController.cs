using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInputActions;
    private InputAction move;
    private Vector2 velocity;
    public float speed = 5f;

    public float fireRate = 0.25f;
    private float nextFire;
    public GameObject shot;
    public Transform shotSpawn;

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
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    private void FixedUpdate()
    {
        // Get movement input as a Vector2 from the input system
        velocity = move.ReadValue<Vector2>();

        // Check if there is movement input
        if (velocity != Vector2.zero)
        {
            // Create a movement vector based on the input
            Vector3 movement = new Vector3(velocity.x, 0.0f, velocity.y);

            // Apply movement to the Rigidbody using world-space velocity
            rb.velocity = transform.TransformDirection(movement * speed);
        }
        else
        {
            // Stop the Rigidbody's movement if no input is detected
            rb.velocity = Vector3.zero;
        }
    }

    public Vector3 GetMovementDirection()
    {
        // Return the normalized movement direction vector scaled by speed
        return new Vector3(velocity.x, 0, velocity.y).normalized * speed;
    }
}
