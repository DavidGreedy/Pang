using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour {

    public GameObject ballObj, ballSpawnPlayer, ballSpawnAI, pauseMenu, playerPaddle, aiPaddle;

    Rigidbody ballRb, paddleRb;

    public int playerScore, aiScore, playerHits, targetScore;

    public float matchTimer, serveThrust, superHitThrust;

    public static bool matchPlaying, isPaused;

    public static bool toServe, aiToServe;

	// Use this for initialization
	void Start ()
    {
        ballRb = ballObj.GetComponent<Rigidbody>();
        paddleRb = playerPaddle.GetComponent<Rigidbody>();
        PlayerToServe();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isPaused && matchPlaying)
        {
            matchTimer += 1 * Time.deltaTime;
        }

        if(toServe)
        {
            ballObj.transform.position = ballSpawnPlayer.transform.position;
        }

        if (aiToServe)
        {
            ballObj.transform.position = ballSpawnAI.transform.position;
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

    void OnHit()
    {
        ballRb.AddForce(paddleRb.velocity.x, paddleRb.velocity.x, 0, ForceMode.Impulse);

        playerHits++;
    }

    public void PlayerToServe()
    {
        toServe = true;
        ballObj.transform.position = ballSpawnPlayer.transform.position;
    }


    public void ServeBall()
    {
        toServe = false;
        ballRb.AddForce(Vector3.forward * serveThrust);
    }

    void AIServe()
    {
        aiToServe = true;
        ballObj.transform.position = ballSpawnAI.transform.position;
        //choose random position in area
        //
        aiToServe = false;
        ballRb.AddForce(Vector3.forward * serveThrust);
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
        ballRb.velocity = new Vector3(0,0,0);
    }
}
