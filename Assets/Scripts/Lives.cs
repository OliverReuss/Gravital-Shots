using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private int lives = 3;

    private TMP_Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        if (HUD != null)
        {
            livesText = HUD.GetComponentInChildren<TMP_Text>();
            if (livesText == null)
            {
                Debug.LogError("No TMP_Text component found in HUD's children.");
            }
        }
        else
        {
            Debug.LogError("HUD GameObject is not assigned.");
        }
        livesText.SetText($"Lives: {lives}");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.K))
        //{
        //    Debug.Log("k");
        //    ReduceLives();
        //}
        livesText.SetText($"Lives: {lives}");
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void ReduceLives()
    {
        // This method will be called by SendMessage
        lives--;
        Debug.Log($"Lives reduced to: {lives}");
        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.SetText($"Lives: {lives}");
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        //GameOver screen pops off

    }
}
