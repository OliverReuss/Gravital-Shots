using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public float lifetime = 2f;
    public float speed = 5f;
    private Vector3 shotDirection;
    private GameObject player;
    private MovementController movementController;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        movementController = player.GetComponent<MovementController>();

        // Get the direction the playe is facing when fiering to make the shot move there
        shotDirection = player.transform.forward;

        // Destroy the shot after a certain time
        Destroy(gameObject, lifetime);

        // Set the velocity when instanciating the shot
        GetComponent<Rigidbody>().velocity = shotDirection * speed;       
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the shot hits something
        if (other.tag == "Enemy")
        {
            movementController.score++;
            Destroy(gameObject);
        }
    }
}
