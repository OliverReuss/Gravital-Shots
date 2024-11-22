using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem engineParticles;
    private Rigidbody playerRb;
    private float forwardSpeed;

    private void Start()
    {
        engineParticles = GetComponent<ParticleSystem>();
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calculate the velocity in the local forward direction
        forwardSpeed = Vector3.Dot(playerRb.velocity, transform.forward);

        // Emit particles when moving forward
        if (forwardSpeed >= 0)
        {
            if (!engineParticles.isPlaying) // Only play if not already playing
            {
                engineParticles.Play();
                Debug.Log("Play");
            }
        }
        // Stop particles when moving backward or not moving forward
        else
        {
            if (engineParticles.isPlaying) // Only stop if it's playing
            {
                engineParticles.Stop();
                Debug.Log("Stop");
            }
        }
    }
}
