using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionsButton : MonoBehaviour
{
    [SerializeField] private Button beginButton;

    void Start()
    {
        // Dynamically find the button if it's not assigned in the Inspector
        if (beginButton == null)
        {
            beginButton = GetComponentInChildren<Button>();
            if (beginButton == null)
            {
                Debug.LogError("BeginButton not assigned and could not be found as a child!");
                return;
            }
        }
        else
        {
            Debug.Log("yay");
        }

        // Add the listener to the button's onClick event
        beginButton.onClick.AddListener(OnBeginButtonClicked);
        Debug.Log("BeginButton listener added.");
    }

    // Method triggered when the button is clicked
    void OnBeginButtonClicked()
    {
        Debug.Log("Begin button clicked. Loading 'Stage1' scene...");
        SceneManager.LoadScene("Stage1"); // Ensure the scene name matches the Build Settings
    }
}
