using UnityEngine;

public class GravityController : MonoBehaviour
{
    private Rigidbody rb;
    private MovementController movementController;
    private Vector3 lastKnownPos;

    private void Start()
    {
        // Initialize Rigidbody and MovementController references
        rb = GetComponent<Rigidbody>();
        movementController = GameObject.FindWithTag("Player").GetComponent<MovementController>();
    }

    private void FixedUpdate()
    {
        // Get the movement direction from the MovementController
        Vector3 movement = movementController.GetMovementDirection();

        // Cast a ray downward from the player's current position to detect surfaces
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;

        // Check if the ray hits any surface within 5 units
        if (Physics.Raycast(ray, out hitInfo, 5f) && hitInfo.collider.gameObject.tag != "Shot" && hitInfo.collider.gameObject.tag != "Player")
        {
            // Adjust the player's position to stay on the surface
            // The player's position is set to the surface point plus a slight offset to prevent clipping
            transform.position = hitInfo.point + transform.up/2;

            // Align the player's rotation to match the surface normal
            Vector3 surfaceNormal = hitInfo.normal;

            // Calculate the forward direction relative to the surface
            Vector3 forward = Vector3.ProjectOnPlane(transform.forward, surfaceNormal).normalized;

            // If the forward direction has a valid magnitude, align the player's rotation smoothly
            if (forward.magnitude > 0.1f)
            {
                // Smoothly interpolate the player's rotation to match the target
                Quaternion targetRotation = Quaternion.LookRotation(forward, surfaceNormal);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }

            // Update the last known valid position
            lastKnownPos = transform.position;
        }
        else
        {
            // If the player is not grounded and there's a known valid position, revert to it
            if (lastKnownPos != Vector3.zero)
            {
                transform.position = lastKnownPos;
            }
        }
    }
}
