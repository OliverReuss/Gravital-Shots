using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInputActions;
    private InputAction move;

    private Vector2 velocity;
    public float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInput();
        move = playerInputActions.Player.Move;
        move.Enable();
    }

    private void FixedUpdate()
    {
        // Get movement input
        velocity = move.ReadValue<Vector2>();

        if (velocity != Vector2.zero)
        {
            Vector3 movement = new Vector3(velocity.x, 0.0f, velocity.y);
            rb.velocity = transform.TransformDirection(movement * speed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public Vector3 GetMovementDirection()
    {
        return new Vector3(velocity.x, 0, velocity.y).normalized * speed;
    }
}
