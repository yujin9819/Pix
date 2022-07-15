using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject btnContinue;
    public GameObject btnQuit;
    public GameObject btnOption;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void PauseBtnOn()
    {
        pauseUI.SetActive(true);
        EffectSound.BtnSoundPlay();
        Time.timeScale = 0;
    }
    public void Continue()
    {
        pauseUI.SetActive(false);
        EffectSound.BtnSoundPlay();
        Time.timeScale = 1;
    }
    public void Quit()
    {
        EffectSound.BtnSoundPlay();
        Application.Quit();
    }
}
