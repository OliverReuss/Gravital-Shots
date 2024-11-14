using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScriptToActivateEscapeButtonHud : MonoBehaviour
{
    public GameObject HUD;

    void Start()
    {
        HUD.SetActive(false); // Ensure the HUD is hidden at the start
    }

    void Update()
    {
        // Check for the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
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
            Debug.Log("Should be active");
            HUD.SetActive(false); // Hide the HUD if it’s already active
        }
        else
        {
            Debug.Log("Should be inactive");
            HUD.SetActive(true); // Show the HUD if it’s inactive
        }
    }
}
