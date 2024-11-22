 using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float lives = 2f;
    public float range = 5f;
    private bool canShoot = true;
    private GameObject player;
    private GameObject shot;
    private Rigidbody rb;
    private GameController gameController;

    void Start()
    {
        // Get the game controller to update the amount of enemies left when a shot destroys one
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        shot = Resources.Load<GameObject>("Shot");
    }

    void Update()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        // Calculate a forward direction that is aligned with the current rotation
        Vector3 forward = Vector3.ProjectOnPlane(directionToPlayer, transform.up).normalized;

        // Align the enemy to face the player, keeping the current surface alignment
        if (forward.magnitude > 0.1f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(forward, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        // Move towards the player if they are out of range
        if (Vector3.Distance(transform.position, player.transform.position) > range)
        {
            transform.position += forward * speed * Time.deltaTime;
        }
        else
        {
            // Stop the enemy from drifting away from the player
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Shooting
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance <= range && canShoot)
            {
                StartCoroutine(FireShot(player));
            }
        }
    }

    private IEnumerator FireShot(GameObject target)
    {
        canShoot = false;

        // Instantiate a shot and set this game object as its origin and set the enemy as its target
        GameObject newShot = Instantiate(shot, transform.position, transform.rotation);
        newShot.GetComponent<ShotScript>().SetOrigin(gameObject);
        newShot.GetComponent<ShotScript>().SetTarget(target);

        // Wait for 2 seconds before allowing the next shot
        yield return new WaitForSeconds(2f);

        canShoot = true;
    }

    public void HitRecieved()
    {
        lives--;

        if (lives <= 0)
        {
            // Destroy the enemy
            Destroy(gameObject);

            // Decrease the enemy count
            gameController.DecreaseEnemyCount();
        }
    }
}
