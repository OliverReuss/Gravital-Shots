using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for Button component
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    // References to UI elements
    public GameObject pauseButtonCanvas;   // Reference to the Pause Button Canvas
    public GameObject pauseMenuCanvas;     // Reference to the Pause Menu Canvas
    public Button pauseButton;             // Reference to the Pause Button component
    public Button resumeButton;            // Reference to the Resume Button component
    public Button exitButton;              // Reference to the Exit Button component

    private bool isPaused = false;

    void Start()
    {
        // Initialize UI visibility
        pauseMenuCanvas.SetActive(false);  // Hide the pause menu at the start
        pauseButtonCanvas.SetActive(true); // Ensure the pause button canvas is visible

        // Add listeners to buttons
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(Pause);
        }

        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(Resume);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitToMainMenu);
        }
    }

    void Update()
    {
        // Toggle pause menu with the Escape key
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("escape key pressed");
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }
    bool getActive(){ return isPaused; }
    // Method to pause the game
    public void Pause()
    {
        Debug.Log("Should be inactive");
        pauseButtonCanvas.SetActive(false); // Hide the pause button canvas
        Time.timeScale = 0f;                // Freeze the game
        isPaused = true;
    }

    // Method to resume the game
    public void Resume()
    {
        Debug.Log("Should be active");
        pauseButtonCanvas.SetActive(true);  // Show the pause button canvas
        pauseMenuCanvas.SetActive(false);   // Hide the pause menu canvas
        Time.timeScale = 1f;                // Unfreeze the game
        isPaused = false;
    }

    // Method to exit to the main menu
    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;                // Ensure the game is unpaused
        SceneManager.LoadScene("Menu");     // Load the main menu scene (replace "Menu" with your actual scene name)
    }
}
