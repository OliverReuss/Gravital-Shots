using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverScreenScript : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; // Reference to the GameOver HUD

    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Ensure it's hidden initially
        }
    }

    public void TriggerGameOver()
    {
        Debug.LogError("Game Over triggered!");
        if (gameOverPanel != null)
        {
            Debug.Log("Gameover not null");
            gameOverPanel.SetActive(true); // Show the GameOver panel
            Time.timeScale = 0f; // Pause the game
        }
    }
}
