using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public GameObject descriptionPanel;

    public void GameStartBtn()
    {
        SceneManager.LoadScene("Lv1");
    }

    public void GameDescriptionBtn()
    {
        descriptionPanel.SetActive(true);
    }

    public void GameDescriptionExitBtn()
    {
        descriptionPanel.SetActive(false);
    }
}
