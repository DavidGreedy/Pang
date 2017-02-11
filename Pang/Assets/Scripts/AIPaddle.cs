using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public GameObject ballTarget;
    public float aiPlayerSpeed;
    public Paddle controlledPaddle;

    private void Awake()
    {
        controlledPaddle.Speed = aiPlayerSpeed;
    }

    void Update()
    {
        AIBehaviour();
        //aiPlayerSpeed = GameManager.Instance.paddleDifficultyAmount;
    }

    void AIBehaviour()
    {
        if (Gameplay.Instance.CurrentServer == this)
        {
            controlledPaddle.Serve();
        }
        if (Gameplay.Instance.matchPlaying)
        {
            controlledPaddle.SetTargetPos(new Vector3(ballTarget.transform.position.x, ballTarget.transform.position.y, 0));
        }
    }
}
