using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    protected Vector3 hitDir;

    public GameObject thisPaddle;
    public Vector3 paddleVel;
    private Vector3 lastPadPos;

    public Vector3 HitDirection
    {
        get { return hitDir; }
    }

    [SerializeField]
    protected float speed;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    [SerializeField]
    private float zPosition;
    public float PosZ
    {
        get { return zPosition; }
    }

    [SerializeField]
    private float hitForce;

    public float HitForce { get { return hitForce; } }

    private Vector3 targetPosition;

    public bool boostTokenActive;
    public int boostTokensRemaining;

    public Vector3 ServePosition
    { get { return transform.position + (HitDirection * 0.2f); } }

    private int hitCount;

    public enum ClampMode
    {
        SQUARE, CIRCLE
    }

    public float clampValueX, clampValueY;

    public ClampMode clampMode;

    private Vector3 previousPosition;
    public float spinPower;

    public Ball ballToServe = null;

    [SerializeField]
    private int score;
    public int Score
    {
        get { return team.Score; }
    }

    [SerializeField]
    private Team team;
    public Team Team
    {
        get { return team; }
    }

    public void AddHit()
    {
        //print(name + " just hit the ball");
        hitCount++;
    }

    private void Start()
    {
        transform.forward = hitDir;
        boostTokensRemaining = GameManager.boostTokenAmt;
        Gameplay.Instance.AddPaddle(this);
    }

    public void SetTargetPos(Vector2 position)
    {
        previousPosition = transform.position;
        targetPosition = new Vector3(position.x, position.y, zPosition);
        transform.Translate((targetPosition - transform.position).normalized * speed * Time.deltaTime, Space.World);
    }

    public void SetPosition(Vector2 position)
    {
        previousPosition = transform.position;
        switch (clampMode)
        {
            case ClampMode.SQUARE:
                {
                    position.x = Mathf.Clamp(position.x, -clampValueX / 2f, clampValueX / 2f);
                    position.y = Mathf.Clamp(position.y, -clampValueY / 2f, clampValueY / 2f);

                    break;
                }
            case ClampMode.CIRCLE:
                {
                    position = Vector2.ClampMagnitude(position, clampValueX / 2f);
                    break;
                }

        }
        transform.position = new Vector3(position.x, position.y, zPosition);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 position = new Vector3(0, 0, transform.position.z);

        switch (clampMode)
        {
            case ClampMode.SQUARE:
                {
                    //Gizmos.DrawWireCube(position, new Vector3(clampValue, clampValue, 0));
                    break;
                }
            case ClampMode.CIRCLE:
                {
                    //Gizmos.DrawWireSphere(position, clampValue / 2f);
                    break;
                }
        }
    }

    void Update()
    {
        Debug.DrawLine(transform.position, targetPosition, Color.green);
    }

    public void Serve()
    {
        if (ballToServe != null)
        {
            ballToServe.Serve(this);
            ballToServe = null;
        }
    }

    public void SetServer(Ball ball)
    {
        print(gameObject.name + " IS SERVING");
        ballToServe = ball;
        ball.transform.position = ServePosition;
        ball.transform.parent = transform;
    }

    public void FixedUpdate()
    {
        paddleVel = (thisPaddle.transform.position - lastPadPos) / Time.deltaTime;
        lastPadPos = thisPaddle.transform.position;
        //print(paddleVel);
    }
}