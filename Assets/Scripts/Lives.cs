using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private int lives = 3;

    private TMP_Text livesText;

    private void Start()
    {
        if (HUD == null)
        {
            Debug.LogError("HUD GameObject is not assigned.");
            return;
        }

        livesText = HUD.GetComponentInChildren<TMP_Text>();
        if (livesText == null)
        {
            Debug.LogError("No TMP_Text component found in HUD's children.");
        }

        UpdateLivesUI();
    }

    public void ReduceLives(int damage)
    {
        Debug.Log("damage");
        lives -= damage;
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
        // Trigger a GameOver UI or scene transition here
    }
}
