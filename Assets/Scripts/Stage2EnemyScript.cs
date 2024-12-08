using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float lives = 2f;
    public float shootingRange = 5f;
    public float detectionRange = 15f;
    private bool canShoot = true;
    private GameObject player;
    private GameObject shot;
    private Rigidbody rb;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        shot = Resources.Load<GameObject>("Shot");
    }

    void Update()
    {
        // Direction to player
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        // Forward direction aligned with current rotation
        Vector3 forward = Vector3.ProjectOnPlane(directionToPlayer, transform.up).normalized;

        // Align to face player and keep current surface alignment
        if (forward.magnitude > 0.1f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(forward, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        // Move towards player out of range
        if (Vector3.Distance(transform.position, player.transform.position) < detectionRange && Vector3.Distance(transform.position, player.transform.position) > shootingRange)
        {
            transform.position += forward * speed * Time.deltaTime;
        }
        else
        {
            // Stop enemy from drifting away
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Shooting
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance <= shootingRange && canShoot)
            {
                StartCoroutine(FireShot(player));
            }
        }
    }

    private IEnumerator FireShot(GameObject target)
    {
        canShoot = false;

        // Instantiate shot set game object as origin and enemy as target
        GameObject newShot = Instantiate(shot, transform.position, transform.rotation);
        newShot.GetComponent<ShotScript>().SetOrigin(gameObject);
        newShot.GetComponent<ShotScript>().SetTarget(target);

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        canShoot = true;
    }

    public void HitRecieved(GameObject attacker)
    {
        MovementController movementController = attacker.GetComponent<MovementController>();

        if (movementController != null && movementController.isPoweredUp)
        {
            // Destroy with one shot when player is powered up
            lives = 0;
        }
        else
        {
            // Reduce lives
            lives--;
        }

        if (lives <= 0)
        {
            Destroy(gameObject);
            gameController.DecreaseEnemyCount();
        }
    }
}
