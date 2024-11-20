using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour
{
    public float range = 5f;
    private GameObject shot;
    private GameObject[] enemies;
    private bool canShoot = true;

    private void Start()
    {
        // Get the shot prefab
        shot = Resources.Load<GameObject>("Shot");
    }

    private void Update()
    {
        // Update the array to always contain the current remaining enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Check for each enemy if it is within range of the drone
        foreach (GameObject enemy in enemies)
        {
            // Calculate the distance between the enemy and the drone
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // Shoot if within range and able to shoot
            if (distance <= range && canShoot)
            {
                // Only fire at one enemy at a time
                StartCoroutine(FireShot(enemy));
                break;
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
}
