using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameManager gameManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            playerController.playerLives = 3;
            playerController.playerDieCnt = 0;
            gameManager.fruitCnt = 0;
            SceneManager.LoadScene("Title");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            Application.Quit();
        }
    }
}
