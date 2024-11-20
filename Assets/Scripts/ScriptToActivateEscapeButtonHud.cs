using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScriptToActivateEscapeButtonHud : MonoBehaviour
{
    public GameObject HUD;

    private InputAction pauseAction;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();

        // Set up the action to listen for the Escape key (or any other key you choose)
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

    void Start()
    {
        HUD.SetActive(false); // Ensure the HUD is hidden at the start
    }

    void Update()
    {
        // Check if the Escape key has been pressed using the new Input System
        if (pauseAction.triggered)
        {
            Debug.Log("Escape key pressed");
            ToggleHUD(); // Toggle the visibility of the HUD
        }
    }

    // Function to toggle the HUD visibility
    void ToggleHUD()
    {
        if (HUD.activeSelf)
        {
            Debug.Log("HUD should be hidden");
            HUD.SetActive(false); // Hide the HUD if it’s already active
        }
        else
        {
            Debug.Log("HUD should be visible");
            HUD.SetActive(true); // Show the HUD if it’s inactive
        }
    }
}
