using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Power Up was triggered");

            MovementController movementController = other.GetComponent<MovementController>();

            if (movementController != null)
            {
                movementController.UpgradeLaser();
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("No MovementController found on the Player");
            }
        }
    }
}