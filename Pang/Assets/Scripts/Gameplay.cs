using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : Singleton<Gameplay>
{
    public int targetScore = 1;
    public int difficulty = 1;

    [SerializeField]
    private Team[] teams;

    [SerializeField]
    private Ball ballPrefab;

    [SerializeField]
    private AIPaddle aiPrefab;

    private Ball ball;

    public PaddleController[] players;

    public Canvas winCanvas;

    public Text[] playerScoreText;
    public Text[] opponentScoreText;

    [SerializeField]
    private Paddle paddlePrefab;

    private void Awake()
    {
        base.Awake();
        teams[0].SetScoresActive(false);
        teams[1].SetScoresActive(false);
    }

    public void Begin()
    {
        ball = Instantiate(ballPrefab);
        Paddle p1Paddle = Instantiate(paddlePrefab);
        players[0].GivePaddle(p1Paddle);
        teams[0].SetPaddle(p1Paddle);
        players[0].SetServer(ball);
        //SetPlayerToServe();
        ball.Reset();
    }

    void SetPlayerToServe()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].tag == "Player")
            {
                players[i].GetComponent<Paddle>().SetServer(ball);
                return;
            }
        }
    }

    public void ScoreEvent(Team scoringTeam) // In the event that someone scores
    {
        if (scoringTeam.Score() == targetScore)
        {
            ActivateWinScreen();
            for (int i = 0; i < players.Length; i++)
            {
                Destroy(players[i]);
            }
            Destroy(ball.gameObject);
        }
        else
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (scoringTeam.paddle != players[i].ControlledPaddle)
                {
                    players[i].SetServer(ball);
                    return;
                }
            }
        }
    }

    void ActivateWinScreen()
    {
        //winCanvas.gameObject.SetActive(true);
        print("WINNER");
    }

    void CreatePlayer()
    {
        if (players[0] != null) // If player one is already assigned then this will be player two
        {
            //players[1] = Instantiate()
        }
    }

    void AddPlayer(PaddleController paddleController, int playerNumber)
    {
        players[playerNumber - 1] = paddleController;
        print("Player " + (playerNumber - 1) + " Joined");
    }
}