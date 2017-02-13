using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    protected Vector3 hitDir;

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

    public event Action OnHit;
    public event Action OnServe;

    private Vector3 targetPosition;

    public bool boostTokenActive;
    public int boostTokensRemaining;

    [SerializeField]
    private Score score;
    public Score ScoreObject { get { return score; } }

    public Vector3 ServePosition
    { get { return transform.position + (HitDirection * 0.5f); } }

    private int hitCount;

    public enum ClampMode
    {
        SQUARE, CIRCLE
    }

    public float clampValue;

    public ClampMode clampMode;

    private Vector3 previousPosition;
    public float spinPower;

    public void AddHit()
    {
        //print(name + " just hit the ball");
        hitCount++;
    }

    private void Start()
    {
        transform.forward = hitDir;
        OnHit += DrawBounceVel;
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
                    position.x = Mathf.Clamp(position.x, -clampValue / 2f, clampValue / 2f);
                    position.y = Mathf.Clamp(position.y, -clampValue / 2f, clampValue / 2f);

                    break;
                }
            case ClampMode.CIRCLE:
                {
                    position = Vector2.ClampMagnitude(position, clampValue / 2f);
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
                    Gizmos.DrawWireCube(position, new Vector3(clampValue, clampValue, 0));
                    break;
                }
            case ClampMode.CIRCLE:
                {
                    Gizmos.DrawWireSphere(position, clampValue / 2f);
                    break;
                }
        }
    }

    void Update()
    {
        Debug.DrawLine(transform.position, targetPosition, Color.green);
    }

    private void DrawBounceVel()
    {
        StartCoroutine(DrawBallBounceVel());
    }

    private IEnumerator DrawBallBounceVel()
    {
        while (true)
        {
            Debug.DrawLine(transform.position, targetPosition, Color.magenta);
            yield return new WaitForSeconds(3f);
        }
    }

    public void Serve()
    {
        Ball ball = Gameplay.Instance.ball;
        ball.transform.parent = null;
        ball.Serve(this);
        if (OnServe != null)
        {
            OnServe.Invoke();
        }
    }

    public void SetServer(Ball ball)
    {
        print(gameObject.name + " IS SERVING");
        ball.transform.position = ServePosition;
        ball.transform.parent = transform;
    }
}