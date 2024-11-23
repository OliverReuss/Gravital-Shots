using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour
{
    public float range = 5f;
    public float rotationSpeed = 2f;
    private GameObject shot;
    private GameObject[] enemies;
    private bool canShoot = true;
    private Transform playerTransform;

    private void Start()
    {
        // Get the shot prefab
        shot = Resources.Load<GameObject>("Shot");

        // Find the player in the scene and reference its transform
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        // Update the array to always contain the current remaining enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        bool enemyInRange = false;

        // Check for each enemy if it is within range of the drone
        foreach (GameObject enemy in enemies)
        {
            // Calculate the distance between the enemy and the drone
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // Rotate towards the enemy if it is within range
            if (distance <= range)
            {
                enemyInRange = true;

                // Calculate the rotation step
                Vector3 directionToEnemy = enemy.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);

                // Smoothly rotate towards the enemy
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // Shoot if within range and able to shoot
                if (canShoot)
                {
                    StartCoroutine(FireShot(enemy));
                    break;
                }
            }
        }

        // If no enemy is within range, rotate back to face the player's forward direction
        if (!enemyInRange)
        {
            // Calculate the rotation to face the player's forward direction
            Quaternion targetRotation = Quaternion.LookRotation(playerTransform.forward);

            // Smoothly rotate towards the player's forward direction
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
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
}
