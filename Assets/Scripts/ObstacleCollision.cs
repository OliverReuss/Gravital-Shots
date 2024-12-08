using System.Collections;
using TMPro;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject livesManager;
    [SerializeField] private float cooldown = 35f; // Cooldown duration
    [SerializeField] private string[] validTags = { "Player" }; // Tags to check against

    private Lives livesScript;
    private bool isCooldownActive = false;

    private void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player GameObject is not assigned.");
        }
        if (livesManager == null)
        {
            Debug.LogError("LivesManager is not assigned.");
        }
        else
        {
            livesScript = livesManager.GetComponent<Lives>();
            if (livesScript == null)
            {
                Debug.LogError("Lives script is not found on the LivesManager.");
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!isCooldownActive && collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerCollision();
        }
    }

    private void HandlePlayerCollision()
    {
        Debug.Log("Player collision detected.");
        if (livesScript != null)
        {
            livesScript.ReduceLives(1); // Call method directly
            StartCoroutine(CollisionCooldown());
        }
        else
        {
            Debug.LogError("Cannot reduce lives; Lives script is missing.");
        }
    }

    private IEnumerator CollisionCooldown()
    {
        isCooldownActive = true;
        yield return new WaitForSeconds(cooldown);
        isCooldownActive = false;
    }

    
}
