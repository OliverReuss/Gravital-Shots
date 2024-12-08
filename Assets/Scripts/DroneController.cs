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
        shot = Resources.Load<GameObject>("Shot");
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        // Update array to contain alive enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        bool enemyInRange = false;

        // Check if enemy is in range
        foreach (GameObject enemy in enemies)
        {
            // Distance to enemy
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // Rotate toward enemy
            if (distance <= range)
            {
                enemyInRange = true;

                Vector3 directionToEnemy = enemy.transform.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);

                // Rotate towards enemy
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // Shoot when in range and able to shoot
                if (canShoot)
                {
                    StartCoroutine(FireShot(enemy));
                    break;
                }
            }
        }

        // Rotate back to players look directio
        if (!enemyInRange)
        {
            Quaternion targetRotation = Quaternion.LookRotation(playerTransform.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private IEnumerator FireShot(GameObject target)
    {
        canShoot = false;

        // Instantiate shot set this game object as origin wiht enemy as target
        GameObject newShot = Instantiate(shot, transform.position, transform.rotation);
        newShot.GetComponent<ShotScript>().SetOrigin(gameObject);
        newShot.GetComponent<ShotScript>().SetTarget(target);

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        canShoot = true;
    }
}
