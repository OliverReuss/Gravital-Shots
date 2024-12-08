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
        enemiesLeft--;
        PlayExplosionSound();

        // Player wins when no enemies left
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
