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

    public Text playerScoreText;
    public Text opponentScoreText;


    private void Awake()
    {
        base.Awake();
        targetScore = GameManager.targetScore;
        if (targetScore == 0)
        {
            targetScore = 2;
        }
        print("Target Score: " + targetScore);
        activePaddles = new List<Paddle>();
    }

    void Start()
    {
        ball.OnScore += ScoreEvent;
        SetPlayerToServe();
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
}