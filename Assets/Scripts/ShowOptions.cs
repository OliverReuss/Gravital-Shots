using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowOptions : MonoBehaviour
{
    public void Options()
    {
        GameObject menuController = GameObject.Find("MenuController");
        MenuButtonRotation menuButtonRotation = menuController.GetComponent<MenuButtonRotation>();

        // Check if button is at front (index 0) and was moved more than a certain time second ago
        if (menuButtonRotation.Cubes[0] == transform.parent.parent.gameObject && Time.time - menuButtonRotation.lastIndexChangeTime > 0.5f)
        {

            SceneManager.LoadScene("Options");
        }
    }
}
