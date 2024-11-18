using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 currentVelocity = Vector3.zero;
    [SerializeField] private float height = 10f;

    private void LateUpdate()
    {
        // Determine the target position by using the player's position and "up" direction
        Vector3 targetPosition = target.position + target.up * height;

        // Smoothly move the camera from its current position to the target position
        transform.position = Vector3.SmoothDamp(current: transform.position, targetPosition, ref currentVelocity, smoothTime);

        // Make the camera look at the player and align the camera's "up" direction with the player's
        transform.LookAt(target.position, target.up);
    }
}
