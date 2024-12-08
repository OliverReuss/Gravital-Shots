using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverScreenScript : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; // Reference to the GameOver HUD
    Button returntoMenuButton;
    private void AttachButtonListener(Button button, UnityEngine.Events.UnityAction action)
    {
        if (button != null)
            button.onClick.AddListener(action);
    }
    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Ensure it's hidden initially
        }

        returntoMenuButton = gameOverPanel.GetComponentInChildren<Button>();

        AttachButtonListener(returntoMenuButton, ExitToMainMenu);
    }

    public void ExitToMainMenu()
    {
        Debug.Log("Scene Changed to Menu");
        Time.timeScale = 1f; // Ensure the game is unpaused
        SceneManager.LoadScene("Menu");
    }

    public void Update()
    {
        

    }
    public void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Show the GameOver panel
            Time.timeScale = 0f; // Pause the game
        }
    }
}
