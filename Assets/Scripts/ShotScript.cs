using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ShotScript : MonoBehaviour
{
    public float lifetime = 2f;
    public float speed = 5f;
    public float shotOffset = 0.5f;
    public GameObject origin;
    private Vector3 direction;
    private Rigidbody rb;
    private MovementController movementController;

    void Start()
    {
        // Get the rigidbody of the shot
        rb = GetComponent<Rigidbody>();

        // Get the player movement script to update score
        movementController = GameObject.FindWithTag("Player").GetComponent<MovementController>();

        // Shoot at the mouse position if the player instantiated the shot
        if (origin.tag == "Player")
        {
            // Create a ray from the camera through the mouse position
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            // Determine the target point
            Vector3 targetPoint = ray.GetPoint(1000f);

            // Calculate the initial direction
            direction = (targetPoint - transform.position).normalized;

            // Position the shot in front of the player, not at the center
            transform.position = origin.transform.position + origin.transform.forward * shotOffset;
        }
        else if(origin.tag == "Enemy" && SceneManager.GetActiveScene().name == "Stage1")
        {
            // Do nothing to keep the shot direction aimed to the player
        }
        else
        {
            // Keep moving towards the target point
            direction = transform.forward;
        }

        // Destroy the shot after a certain time
        Destroy(gameObject, lifetime);
    }

    // Move the shot forward along the surface of the sphere
    void FixedUpdate()
    {
        // Cast a ray downward to find the surface normal
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 5f))
        {
            // Update direction to be tangent to the surface
            direction = Vector3.ProjectOnPlane(direction, hitInfo.normal).normalized;

            // Move the shot forward
            transform.position += direction * speed * Time.fixedDeltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
{
    // Player or drone shooting at enemy
    if (other.tag == "Enemy" && origin != null && (origin.tag == "Player" || origin.tag == "Drone"))
    {
        // Update the score
        movementController.score++;

        // Destroy the shot
        Destroy(gameObject);

        // Check if the other object has an EnemyController
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
             var enemyController = other.GetComponent<Stage1EnemyScript>();
             enemyController.HitRecieved(origin);
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            var enemyController = other.GetComponent<EnemyController>();
            enemyController.HitRecieved(origin);
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            // Check for StationaryEnemyController
            var stationaryEnemyController = other.GetComponent<StationaryEnemyController>();
            stationaryEnemyController.HitRecieved(origin);
        }
    }

    // Enemy shooting at player
    if (other.tag == "Player" && origin != null && origin.tag == "Enemy")
    {
        // Destroy the shot
        Destroy(gameObject);

        // Subtract a player life
    }
}

    public void SetOrigin(GameObject o)
    {
        origin = o;
    }

    public void SetTarget(GameObject t)
    {
        Vector3 targetPoint = t.GetComponent<Transform>().position;
        direction = (targetPoint - transform.position).normalized;
    }
}
