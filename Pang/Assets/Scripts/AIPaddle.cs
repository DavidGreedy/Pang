﻿using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public GameObject ballTarget;
    public float aiPlayerSpeed;


    public bool boostTokenActive;
    public int boostTokensRemaining;


    public Paddle controlledPaddle;

    private void Awake()
    {
        boostTokensRemaining = GameManager.boostTokenAmt;
        controlledPaddle.Speed = GameManager.paddleDifficultyAmount;
    }

    void Update()
    {
        AIBehaviour();
        //aiPlayerSpeed = GameManager.Instance.paddleDifficultyAmount;
    }

    void AIBehaviour()
    {
        switch (Gameplay.Instance.State)
        {
            case Gameplay.GameState.SERVING:
                {
                    if (Gameplay.Instance.CurrentServer == controlledPaddle)
                    {
                        Invoke("Serve", 0.5f);
                    }
                    break;
                }
            case Gameplay.GameState.PLAYING:
                {
                    controlledPaddle.SetTargetPos(new Vector3(ballTarget.transform.position.x, ballTarget.transform.position.y, 0));
                    break;
                }
        }
    }

    void Serve()
    {
        controlledPaddle.Serve();
    }
}
