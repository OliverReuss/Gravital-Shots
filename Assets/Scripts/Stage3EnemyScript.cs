using UnityEngine;
using System.Collections;

public class StationaryEnemyController : MonoBehaviour
{
    public float lives = 4f; // Stationary enemy starts with 4 lives
    public float rotationSpeed = 45f; // Degrees per second
    public float shotDelay = 0.25f;
    public GameObject shot;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        if (shot == null)
        {
            shot = Resources.Load<GameObject>("Shot");
        }

        // Start shooting
        StartCoroutine(ShootContinuously());
    }

    void Update() //Rotate enemy
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator ShootContinuously()
    {
        while (true)
        {
            FireShot();
            yield return new WaitForSeconds(shotDelay);
        }
    }

    private void FireShot()
    {
        GameObject newShot = Instantiate(shot, transform.position, transform.rotation);
        newShot.GetComponent<ShotScript>().SetOrigin(gameObject);
    }

    public void HitRecieved(GameObject attacker)
    {
        MovementController movementController = attacker.GetComponent<MovementController>();

        if (movementController != null && movementController.isPoweredUp)
        {
            //If player has power up 1 shot the enemies
            lives = 0;
        }
        else
        {
            // else take 1 life off enemy
            lives--;
        }

        if (lives <= 0)
        {
            Destroy(gameObject);
            gameController.DecreaseEnemyCount();
        }
    }
}
