﻿using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Paddle : NetworkBehaviour
{
    [SerializeField]
    protected Vector3 hitDir;

    public Vector2 Velocity { get { return transform.position - previousPosition; } }

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
    private float hitForce;

    public float HitForce { get { return hitForce; } }

    public Vector3 ServePosition
    { get { return transform.position + (HitDirection * 0.2f); } }

    public enum ClampMode
    {
        SQUARE, CIRCLE
    }

    public float clampValueX, clampValueY;

    public ClampMode clampMode;

    private Vector3 previousPosition;

    public Ball ballToServe = null;

    public Team team;

    public event Action OnSetServe;

    public void AssignTeam(Team team)
    {
        this.team = team;
    }

    public void Init()
    {
        transform.forward = hitDir;
    }

    public void SetPosition(Vector3 position)
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
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

    public void AddScore(int amount)
    {
        team.AddScore(amount);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Velocity.normalized, Color.green);
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
        if (OnSetServe != null)
        {
            OnSetServe.Invoke();
        }
    }
}