using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject gameOverUI; // Reference to the GameOverUIController
    [SerializeField] private GameoverScreenScript script;
    [SerializeField] private int lives = 3;//change for player's lives

    private TMP_Text livesText;

    private float cooldown = 5f;
    private bool isCooldownActive = false;

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
        if (gameOverUI == null)
        { 
            Debug.LogError("Gameover Lose Canvas GameObject not found.");
        }

            UpdateLivesUI();
    }
    public void Update()
    {
        if (isCooldownActive)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                cooldown = 35f; // Reset cooldown
                isCooldownActive = false;
            }
        }
        if (lives <= 0)
        {
            GameOver();
        }
    }
    public void ReduceLives(int damage)
    {
        lives -= damage;
        Debug.Log($"Lives reduced to: {lives}");
        UpdateLivesUI();

        
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.SetText(lives <= 0 ? "Lives: 0" : $"Lives: {lives}");
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over logic triggered.");
        if (gameOverUI != null)
        {
            Debug.Log("Gameover not null");
            script.TriggerGameOver();
            //gameOverUI.SendMessage("TriggerGameOver", SendMessageOptions.DontRequireReceiver); // Send message to the GameOverUIController
        }
        else
        {
            Debug.LogError("GameOverScreenScript reference is not assigned.");
        }
    }


    private void OnTriggerEnter(Collider other) //attached to player for this to work
    {
        if (other.CompareTag("Shot") && !isCooldownActive)
        {
            Debug.Log("playershot!!!!");
            ReduceLives(1);
        }
    }
}
