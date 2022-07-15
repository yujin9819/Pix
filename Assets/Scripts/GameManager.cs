using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject fallPlatPrefab;
    private int score;
    private int banana = 0;
    [SerializeField] private float time = 120f;
    private int min;
    private int sec;
    private int playerDieCnt;
    public int fruitCnt = 0;
    [SerializeField] Text PlayerLivesText;
    [SerializeField] Text fruitCountText;

    [SerializeField] GameObject goalBG;
    [SerializeField] GameObject goalPanel;

    [SerializeField] Text txtLives;
    [SerializeField] Text txtTime;
    [SerializeField] Text txtBanana;
    [SerializeField] Text txtScore;

    [SerializeField] Text timer;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject strawberryText;

    private bool isGoal = false;

    private void Start()
    {
        Events();
        Time.timeScale = 1;
    }

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        if (time > 0 && !isGoal)
        {
            time -= Time.deltaTime;
            min = (int)time / 60;
            sec = (int)time % 60;
            timer.text = "0" + min.ToString() + ":" + sec.ToString();
            if (time < 5)
            {
                timer.color = Color.red;
            }
        }
        if (time < 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOver.SetActive(false);
                Time.timeScale = 1;
                EventManager.instance.SendEvent("PlayerRespawn");
                time = 120f;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
    private void Events()
    {
        EventManager.instance.AddEvent("PlayerLivesText", p => { PlayerLivesText.text = "X " + p; });
        EventManager.instance.AddEvent("CollectedFruit", p => {
            fruitCnt++;
            fruitCountText.text = fruitCnt.ToString();
        });

        EventManager.instance.AddEvent("RespawnFallPlat", p =>
        {
            Destroy(GameObject.Find("FallPlat"));
            var c = Instantiate(fallPlatPrefab);
            c.name = "FallPlat";
        });

        EventManager.instance.AddEvent("BananaScore", p => banana++ );

        EventManager.instance.AddEvent("LivesScore", p => playerDieCnt = (int)p );

        EventManager.instance.AddEvent("SetGoal", p => 
        {
            SetGoal();
            SetScore();
        });
        EventManager.instance.AddEvent("StrawberryText", p => 
        {
            StartCoroutine(Text());
        });
    }

    public void SetScore()
    {
        score = banana * 20 + (int)time * 20 + -playerDieCnt * 10;

        txtLives.text = "플레이어가 사망한 횟수: " + playerDieCnt;
        txtBanana.text = "모은 바나나 갯수: " + banana + "개";
        txtTime.text = "남은 시간: " + Mathf.Round(time) + "초";
        txtScore.text = "총 점수: " + score + "점";
    }

    private void SetGoal()
    {
        isGoal = true;
        goalBG.SetActive(true);
        StartCoroutine(Goal());
    }

    IEnumerator Text()
    {
        strawberryText.SetActive(true);
        yield return new WaitForSeconds(1f);
        strawberryText.SetActive(false);
    }
    IEnumerator Goal()
    {
        yield return new WaitForSeconds(1f);
        goalPanel.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Time.timeScale = 0;
    }

    public void BtnHome()
    {
        SceneManager.LoadScene("Title");
    }
}
