using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool playerWin = false;

    private AudioSource audioSource;
    public AudioClip explosionSound;

    public string[] stages = {"Stage1", "Stage2", "Stage3" }; // Array to hold stage names


    void Start()
    {
        GameData.EnemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
}

public void DecreaseEnemyCount()
    {
        GameData.EnemiesLeft--;
        PlayExplosionSound();

        // Player wins when no enemies left
        if (GameData.EnemiesLeft == 0)
        {
            playerWin = true;
            Debug.Log("You Win!");
            Invoke("LoadNextStage", 2f); // Delay before transitioning to the next stage
        }
    }

    private void LoadNextStage()
    {

        if (GameData.CurrentStageIndex < stages.Length - 1)//0, 1, 2
        {
            GameData.CurrentStageIndex++;
            Debug.Log($"Current Stage Index: {GameData.CurrentStageIndex}, Loading Scene: {stages[GameData.CurrentStageIndex]}");
            SceneManager.LoadScene(stages[GameData.CurrentStageIndex]);

        }
        else
        {
            SceneManager.LoadScene("GameOver"); // Load game over if no more stages
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
