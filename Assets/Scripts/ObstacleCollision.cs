using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject livesManager;

    private CapsuleCollider playerCapsuleCollider;
    private float cooldown = 5f;
    private bool isCooldownActive = false;

    void Start()
    {

        // check for null references
        

        if (player != null)
        {
            playerCapsuleCollider = player.GetComponent<CapsuleCollider>();
            if (playerCapsuleCollider == null)
            {
                Debug.LogError("No Rigidbody component found on the player.");
            }
        }
        else
        {
            Debug.LogError("Player GameObject is not assigned.");
        }
        if (livesManager != null) { }
        else
        {
            Debug.LogError("LivesManager not assigned");
        }

        
    }

    void Update()
    {
        
        if (isCooldownActive)
        {
            cooldown -= Time.deltaTime;

            if (cooldown <= 0)
            {
                cooldown = 5f; // Reset cooldown
                isCooldownActive = false;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player && !isCooldownActive)
        {
            Debug.Log("IS COLLIDING");
            isCooldownActive = true;
            //
            livesManager.SendMessage("ReduceLives", SendMessageOptions.DontRequireReceiver);
        }
    }

    
}
