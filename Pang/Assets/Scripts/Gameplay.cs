﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay : Singleton<Gameplay>
{
    public int targetScore = 1;

    public Ball ball;

    public List<Paddle> activePaddles;
    private int currentServeIndex = 0;

    [SerializeField]
    private SceneManagement sceneManager;

    public Canvas winCanvas;

    public Paddle CurrentServer
    {
        get { return activePaddles[currentServeIndex]; }
    }

    [SerializeField]
    private bool isRandomServeOrder;

    public List<Text> scoreUIList;

    public enum GameState
    {
        SERVING,
        PLAYING
    }

    private GameState gameState;

    public GameState State
    {
        get { return gameState; }
    }

    private void Awake()
    {
        base.Awake();
        targetScore = GameManager.targetScore;
        print("Target Score: " + targetScore);
        activePaddles = new List<Paddle>();
    }

    void DecideServeOrder()
    {
        if (isRandomServeOrder)
        {
            activePaddles.Shuffle();
        }
        else
        {
            for (int i = 0; i < activePaddles.Count; i++)
            {
                if (activePaddles[i].tag == "Player")
                {
                    currentServeIndex = i;
                    return;
                }
            }
        }
    }

    void Start()
    {
        DecideServeOrder();
        SelectNextServer();
        UpdateScoreUI();
    }

    void SelectNextServer()
    {
        CurrentServer.SetServer(ball);
        ball.gameObject.SetActive(true);
        gameState = GameState.SERVING;
    }

    void OnPaddleServe()
    {
        currentServeIndex++;

        if (currentServeIndex == activePaddles.Count)
        {
            currentServeIndex = 0;
        }
        gameState = GameState.PLAYING;
    }

    void CheckWinner()
    {
        bool winner = false;
        for (int i = 0; i < activePaddles.Count; i++)
        {
            if (activePaddles[i].ScoreObject.ScoreValue == targetScore)
            {
                // PADDLE HAS WON
                print(activePaddles[i].name + " HAS WON");
                ActivateWinScreen();
                winner = true;
            }
        }

        if (!winner)
        {
            UpdateScoreUI();
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
        paddle.OnServe += OnPaddleServe;
        paddle.ScoreObject.OnScore += CheckWinner;
        paddle.ScoreObject.OnScore += SelectNextServer;
    }

    private void UpdateScoreUI()
    {
        print("UPDATING SCORE UI");
        for (int i = 0; i < activePaddles.Count; i++)
        {
            scoreUIList[i].text = activePaddles[i].ScoreObject.ScoreValue.ToString();
        }
        scoreUIList[2].text = activePaddles[1].ScoreObject.ScoreValue.ToString();
        scoreUIList[3].text = activePaddles[0].ScoreObject.ScoreValue.ToString();
    }
}