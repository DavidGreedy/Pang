using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : Singleton<Gameplay>
{
    public int playerHits, targetScore;

    public float matchTimer, serveThrust, superHitThrust;

    public bool matchPlaying, isPaused;

    public bool toServe, aiToServe;

    public event Action OnHit;

    public Ball ball;

    public List<Paddle> activePaddles;
    private int currentServeIndex = 0;

    public Paddle CurrentServer { get { return activePaddles[currentServeIndex]; } }

    [SerializeField]
    private bool isRandomServeOrder;

    public List<Text> scoreUIList;

    public enum GameState
    {
        SERVING, PLAYING
    }

    private GameState gameState;


    public GameState State
    {
        get { return gameState; }
    }

    private void Awake()
    {
        base.Awake();
        targetScore = GameManager.paddleDifficultyAmount;
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
        matchPlaying = true;
        DecideServeOrder();
        SelectNextServer();
        UpdateScoreUI();
    }

    void SelectNextServer()
    {
        CurrentServer.SetServer(ball);
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

    void Update()
    {
        Debug.DrawLine(ball.transform.position, CurrentServer.transform.position);
        if (!isPaused && matchPlaying)
        {
            matchTimer += Time.deltaTime;
        }
    }

    void Pause()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ball")
        {
            if (OnHit != null)
            {
                OnHit.Invoke();
            }
        }
    }

    public void AddPaddle(Paddle paddle)
    {
        activePaddles.Add(paddle);
        paddle.OnServe += OnPaddleServe;
        paddle.ScoreObject.OnScore += UpdateScoreUI;
        paddle.ScoreObject.OnScore += SelectNextServer;
    }

    public void UpdateScoreUI()
    {
        for (int i = 0; i < activePaddles.Count; i++)
        {
            scoreUIList[i].text = activePaddles[i].ScoreObject.ScoreValue.ToString();
        }
            scoreUIList[2].text = activePaddles[1].ScoreObject.ScoreValue.ToString();
            scoreUIList[3].text = activePaddles[0].ScoreObject.ScoreValue.ToString();
    }
}
