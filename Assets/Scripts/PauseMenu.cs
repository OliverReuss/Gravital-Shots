using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class HUD : MonoBehaviour
{
    // References to UI elements
    [SerializeField] private GameObject pauseButton; // The pause button
    [SerializeField] private GameObject pauseMenuPanel; // The pause menu panel

    private bool isPaused = false;

    private InputAction pauseAction;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();

        // Set up the action to listen for the Escape key (or any other key)
        pauseAction = playerInput.Player.Pause;
    }

    private void OnEnable()
    {
        // Enable the pause action
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the pause action
        pauseAction.Disable();
    }

    private void AttachButtonListener(Button button, UnityEngine.Events.UnityAction action)
    {
        if (button != null)
            Debug.Log("button localized");
            button.onClick.AddListener(action);
    }

    void Start()
    {
        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true);

        Button pauseButtonComponent = pauseButton.GetComponent<Button>();
        if (pauseButtonComponent)
        {
            AttachButtonListener(pauseButtonComponent, Pause);
        }
        else
        {
            Debug.LogError("Pause button not found.");
        }

        Button resumeButton = pauseMenuPanel.transform.Find("Resume")?.GetComponent<Button>();
        if (resumeButton)
        {
            AttachButtonListener(resumeButton, Resume);
        }
        else
        {
            Debug.LogError("Resume button not found or has no Button component.");
        }

        Button exitButton = pauseMenuPanel.transform.Find("Exit")?.GetComponent<Button>();
        if (exitButton)
        {
            AttachButtonListener(exitButton, ExitToMainMenu);
        }
        else
        {
            Debug.LogError("Exit button not found or has no Button.");
        }
    }


    void Update()
    {
        // Check if the pause button action was triggered
        if (pauseAction.triggered)
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        Debug.Log("Game Paused");
        pauseButton.SetActive(false); // Hide the pause button
        pauseMenuPanel.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
    }

    public void Resume()
    {
        Debug.Log("Game Resumed");
        pauseButton.SetActive(true); // Show the pause button
        pauseMenuPanel.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
    }

    public void ExitToMainMenu()
    {
        Debug.Log("Scene Changed to Menu");
        Time.timeScale = 1f; // Ensure the game is unpaused
        SceneManager.LoadScene("Menu"); // Load the main menu scene
    }
}
