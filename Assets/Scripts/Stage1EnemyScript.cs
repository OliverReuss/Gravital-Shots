using UnityEngine;
using System.Collections;

public class Stage1EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float lives = 2f;
    public float shootingRange = 10f;
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
        // Calculate forward direction
        Vector3 forward = Vector3.ProjectOnPlane(transform.forward, transform.up).normalized;

        // Keep moving forward
        transform.position += forward * speed * Time.deltaTime;

        // Shooting
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= shootingRange && canShoot)
        {
            StartCoroutine(FireShot(player));
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
            // Destroy enemy with one shot when player is powered up
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
