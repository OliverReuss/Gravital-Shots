using UnityEngine;

public class GravityController : MonoBehaviour
{
    private Rigidbody rb;
    private MovementController movementController;

    private Vector3 lastKnownPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementController = GetComponent<MovementController>();
    }

    private void FixedUpdate()
    {
        //Get player movement 
        Vector3 movement = movementController.GetMovementDirection();

        //Cast a ray downward to check if the player is grounded
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 5f))
        {
            //Align player to the surface
            transform.position = hitInfo.point + transform.up;

            // Align rotation to surface normal
            Vector3 surfaceNormal = hitInfo.normal;
            Vector3 forward = Vector3.ProjectOnPlane(transform.forward, surfaceNormal).normalized;

            if (forward.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(forward, surfaceNormal);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }

            lastKnownPos = transform.position;
        }
        else
        {
            if (lastKnownPos != Vector3.zero)
            {
                transform.position = lastKnownPos;
            }
        }
    }
}
