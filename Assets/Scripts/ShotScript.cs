using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.IO.LowLevel.Unsafe;

public class ShotScript : MonoBehaviour
{
    public float lifetime = 2f;
    public float speed = 5f;
    private GameObject player;
    private MovementController movementController;
    private GameController gameController;
    private Transform firePoint;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        movementController = player.GetComponent<MovementController>();
        firePoint = player.GetComponent<Transform>();
        Collider playerCollider = player.GetComponent<Collider>();
        Rigidbody rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        // Create a ray from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the target point
        Vector3 targetPoint = ray.GetPoint(1000f);

        // Direction from fire point to the target
        Vector3 direction = (targetPoint - firePoint.position).normalized;

        // Set velocity
        rb.velocity = direction * speed;

        // Destroy shot after certain time
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the shot hits something
        if (other.tag == "Enemy")
        {
            // Update the score
            movementController.score++;

            // Destroy the shot
            Destroy(gameObject);

            // Destroy the enemy
            Destroy(other.gameObject);

            // Decrease the enemy count
            gameController.DecreaseEnemyCount();
        }
    }
}
