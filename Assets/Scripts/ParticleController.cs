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
        // Speed in forward direction
        forwardSpeed = Vector3.Dot(playerRb.velocity, transform.forward);

        // Show particles when moving forward
        if (forwardSpeed >= 0)
        {
            if (!engineParticles.isPlaying)
            {
                engineParticles.Play();
            }
        }
        // Stop particles when not moving / moving backwards
        else
        {
            if (engineParticles.isPlaying)
            {
                engineParticles.Stop();
            }
        }
    }
}
