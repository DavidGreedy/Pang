using System;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : Singleton<Gameplay>
{
    public int playerScore, aiScore, playerHits, targetScore;

    public float matchTimer, serveThrust, superHitThrust;

    public bool matchPlaying, isPaused;

    public bool toServe, aiToServe;

    public event Action OnHit;
    public event Action OnServe;

    public Ball ball;

    public List<Paddle> activePaddles;
    private int currentServeIndex = 0;

    public Paddle CurrentServer { get { return activePaddles[currentServeIndex]; } }

    [SerializeField]
    private bool isRandomServeOrder;

    private void Awake()
    {
        base.Awake();
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
        CurrentServer.SetServer(ball);
    }

    void OnPaddleServe()
    {
        currentServeIndex++;

        if (currentServeIndex == activePaddles.Count)
        {
            currentServeIndex = 0;
        }
    }

    void Update()
    {
        Debug.DrawLine(Vector3.zero, CurrentServer.transform.position);
        if (!isPaused && matchPlaying)
        {
            matchTimer += Time.deltaTime;
        }

        if (toServe)
        {
            //ballObj.transform.position = ballSpawnPlayer.transform.position;
        }

        if (aiToServe)
        {
            //ballObj.transform.position = ballSpawnAI.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AIGoal();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerGoal();
        }
    }

    void Pause()
    {

    }

    public void PlayerToServe()
    {
        toServe = true;
        //ballObj.transform.position = ballSpawnPlayer.transform.position;
    }

    public void Shuffle()
    {

    }

    public void ServeBall()
    {
        toServe = false;
        //ball.Hit(null, Vector3.forward, serveThrust);
    }

    void AIServe()
    {
        aiToServe = true;
        //ballObj.transform.position = ballSpawnAI.transform.position;
        //choose random position in area
        //
        aiToServe = false;
        //ballRb.AddForce(Vector3.forward * serveThrust);
    }

    public void AIGoal()
    {
        aiScore++;
        ResetBallVelocity();
        PlayerToServe();
    }

    public void PlayerGoal()
    {
        playerScore++;
        ResetBallVelocity();
        AIServe();
    }

    public void ResetAIPaddle()
    {

    }

    void ResetBallVelocity()
    {
        //ballRb.velocity = new Vector3(0, 0, 0);
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
    }
}
