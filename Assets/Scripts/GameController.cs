using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool playerWin = false;
    public int enemiesLeft;

    private AudioSource audioSource;
    public AudioClip explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void DecreaseEnemyCount()
    {
        // Decrease the count of enemies
        enemiesLeft--;

        PlayExplosionSound();

        // If no enemies are left the player has won
        if (enemiesLeft == 0)
        {
            playerWin = true;
            Debug.Log("You Win!");
        }
    }

    private void PlayExplosionSound()
    {
        if (audioSource != null && explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }
}
