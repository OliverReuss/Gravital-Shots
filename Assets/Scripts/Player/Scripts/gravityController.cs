using UnityEngine;

public class GravityController : MonoBehaviour
{
    private Rigidbody rb;
    private MovementController movementController;
    private Vector3 lastKnownPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementController = GameObject.FindWithTag("Player").GetComponent<MovementController>();
    }

    private void FixedUpdate()
    {
        //Get movement direction from MovementController
        Vector3 movement = movementController.GetMovementDirection();

        //cast a ray downward from the players current position to detect surfaces
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;

        // Check if the ray hits any surface within 5 units
        if (Physics.Raycast(ray, out hitInfo, 5f) && hitInfo.collider.gameObject.tag != "Shot" && hitInfo.collider.gameObject.tag != "Player" && hitInfo.collider.gameObject.tag != "Cube Obstacle")
        {
            if (!IsNearObstacle()) {
                // ajust players position to stay on surface
                transform.position = hitInfo.point + transform.up/2;

                //align players rotation to match surface normal
                Vector3 surfaceNormal = hitInfo.normal;

                // Calculate direction relative to the surface
                Vector3 forward = Vector3.ProjectOnPlane(transform.forward, surfaceNormal).normalized;

                if (forward.magnitude > 0.1f)
                {
                    //interpolate the players rotation to match the target
                    Quaternion targetRotation = Quaternion.LookRotation(forward, surfaceNormal);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
                }

                lastKnownPos = transform.position;
            }
        }
        else
        {
            if (lastKnownPos != Vector3.zero)
            {
                transform.position = lastKnownPos;
            }
        }
    }

    bool IsNearObstacle()//Dan
    {
        //checks for colliders 
        Collider[] obstacles = Physics.OverlapSphere(transform.position, 1f);
        foreach (var obstacle in obstacles)
        {
            if (obstacle.CompareTag("Cube Obstacle")) // Filter by tag
            {
                return true;
            }
        }
        return false;
    }
}
