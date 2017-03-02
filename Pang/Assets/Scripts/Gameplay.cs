using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : Singleton<Gameplay>
{
    public int targetScore = 1;

    [SerializeField]
    private Ball ballPrefab;

    private Ball ball;

    public List<Paddle> activePaddles;

    public Canvas winCanvas;

    public Text[] playerScoreText;
    public Text[] opponentScoreText;

    private void Awake()
    {
        base.Awake();
        targetScore = GameManager.targetScore;
        if (targetScore == 0)
        {
            targetScore = 5;
        }
        print("Target Score: " + targetScore);
        activePaddles = new List<Paddle>();
    }

    public void Begin()
    {
        ball = Instantiate(ballPrefab);
        ball.OnScore += ScoreEvent;
        SetPlayerToServe();
        ball.Reset();
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
        if (scoringPaddle.Score == targetScore)
        {
            ActivateWinScreen();
            for (int i = 0; i < activePaddles.Count; i++)
            {
                Destroy(activePaddles[i].gameObject);
            }
            Destroy(ball.gameObject);
        }
        else
        {
            for (int i = 0; i < activePaddles.Count; i++)
            {
                if (scoringPaddle != activePaddles[i])
                {
                    activePaddles[i].SetServer(ball);
                    return;
                }
            }
        }
    }

    void ActivateWinScreen()
    {
        winCanvas.gameObject.SetActive(true);
    }

    public void AddPaddle(Paddle paddle)
    {
        activePaddles.Add(paddle);
        if (activePaddles.Count == 1)
        {
            activePaddles[0].SetScoreTexts(playerScoreText);
        }
        if (activePaddles.Count == 2)
        {
            activePaddles[1].SetScoreTexts(opponentScoreText);
            Begin();
        }
    }
}