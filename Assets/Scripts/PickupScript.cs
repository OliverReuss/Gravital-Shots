using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Power Up was triggered");
        Debug.Log(other.tag);

        if (other.CompareTag("Player"))
        {
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