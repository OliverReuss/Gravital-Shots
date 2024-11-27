using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject livesManager;

    private float cooldown = 5f;
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
    }

    private void Update()
    {
        if (isCooldownActive)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                cooldown = 10f; // Reset cooldown
                isCooldownActive = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!isCooldownActive) { 
            if (collision.gameObject.CompareTag("Player"))
            {
                HandlePlayerCollision();
            }
        }
    }

    private void HandlePlayerCollision()
    {
        Debug.Log("Player collision detected.");
        livesManager.SendMessage("ReduceLives", 1);
        isCooldownActive = true;
    }
}
