using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool playerWin = false;
    public int enemiesLeft;

    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void DecreaseEnemyCount()
    {
        // Decrease the count of enemies
        enemiesLeft--;

        // If no enemies are left the player has won
        if (enemiesLeft == 0)
        {
            playerWin = true;
            Debug.Log("You Win!");
        }
    }
}
