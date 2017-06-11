using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : Singleton<Gameplay>
{
    public float targetScore = 10;
    public float difficulty = 1;

    public Slider diffSlider;
    public Slider scoreSlider;

    public Text finalScore;
    public GameObject winCanvas;

    public Text obstacleButton;
    public bool obstacleMode;

    [SerializeField]
    private Team[] teams;

    [SerializeField]
    private Ball ballPrefab;

    private Ball ball;

    public PaddleController[] players;

    [SerializeField]
    private Paddle paddlePrefab;

    public bool isPaused;

    private void Awake()
    {
        base.Awake();
        obstacleButton.color = Color.red;
        teams[0].SetScoresActive(false);
        teams[1].SetScoresActive(false);
    }

    public void CreateAIOpponent()
    {
        Paddle p = Instantiate(paddlePrefab, -players[0].transform.position, Quaternion.LookRotation(new Vector3(0, 0, -1)));
        players[1] = p.gameObject.AddComponent<AIPaddle>();
        players[1].GetComponent<AIPaddle>().Init(p, ball, (int)difficulty);
    }

    public void Begin()
    {
        targetScore = scoreSlider.value;
        difficulty = diffSlider.value;
        ball = Instantiate(ballPrefab);
        Paddle p1Paddle = Instantiate(paddlePrefab);
        players[0].GivePaddle(p1Paddle);
        teams[0].SetPaddle(p1Paddle);
        players[0].SetServer(ball);

        teams[0].SetScoresActive(true);
        teams[1].SetScoresActive(true);

        //SetPlayerToServe();
        ball.Reset();
    }

    public void obsMode()
    {
        obstacleMode = !obstacleMode;
        if (obstacleMode == true)
        {
            obstacleButton.color = Color.green;
        }
        else
        {
            obstacleButton.color = Color.red;
        }
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
        scoringTeam.AddScore(1);

        print(string.Format("{0} Scored! ({1})", scoringTeam == teams[0] ? "Team 1" : "Team 2", scoringTeam.Score().ToString()));
        print(string.Format("{0}:{1}", teams[0].Score(), teams[1].Score()));

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
        winCanvas.gameObject.SetActive(true);
        finalScore.text = string.Format("{0}:{1}", teams[0].Score(), teams[1].Score());
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