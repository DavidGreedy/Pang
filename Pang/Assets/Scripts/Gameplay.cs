using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : Singleton<Gameplay>
{
    public int targetScore = 1;

    public Ball ball;

    public List<Paddle> activePaddles;

    [SerializeField]
    private SceneManagement sceneManager;

    public Canvas winCanvas;

    public List<Text> scoreUIList;

    private void Awake()
    {
        base.Awake();
        targetScore = GameManager.targetScore;
        print("Target Score: " + targetScore);
        activePaddles = new List<Paddle>();
    }

    void Start()
    {
        ball.OnScore += ScoreEvent;
        SetPlayerToServe();
        UpdateScoreUI();
    }

    void SetPlayerToServe()
    {
        for (int i = 0; i < activePaddles.Count; i++)
        {
            if (activePaddles[i].tag == "Player")
            {
                activePaddles[i].GetComponent<Paddle>().SetServer(ball);
                return;
            }
        }
    }

    void ScoreEvent(Paddle scoringPaddle) // In the event that someone scores
    {
        if (scoringPaddle.Score > targetScore)
        {
            // scoring paddles has won
            print(scoringPaddle.name + " Won");
            ActivateWinScreen();
        }
        else
        {
            print(scoringPaddle.name + " Scored");
            UpdateScoreUI();
            scoringPaddle.SetServer(ball);
        }
    }

    void ActivateWinScreen()
    {
        winCanvas.gameObject.SetActive(true);
        Invoke("OpenMenuScene", 5f);
    }

    void OpenMenuScene()
    {
        sceneManager.ChangeScene(0);
    }

    public void AddPaddle(Paddle paddle)
    {
        activePaddles.Add(paddle);
    }

    private void UpdateScoreUI()
    {
        for (int i = 0; i < activePaddles.Count; i++)
        {
            scoreUIList[i].text = activePaddles[i].Score.ToString();
        }
        scoreUIList[2].text = activePaddles[1].Score.ToString();
        scoreUIList[3].text = activePaddles[0].Score.ToString();
    }
}