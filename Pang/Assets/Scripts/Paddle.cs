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

    public event Action OnHit;
    public event Action OnServe;

    private Vector3 targetPosition;

    [SerializeField]
    private Score score;
    public Score ScoreObject { get { return score; } }

    public Vector3 ServePosition
    { get { return transform.position + (HitDirection * 0.5f); } }

    private void Start()
    {
        transform.forward = hitDir;
        OnHit += DrawBounceVel;
        Gameplay.Instance.AddPaddle(this);
    }

    public void SetTargetPos(Vector2 position)
    {
        targetPosition = new Vector3(position.x, position.y, zPosition);
        transform.Translate((targetPosition - transform.position).normalized * speed * Time.deltaTime, Space.World);
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Gameplay.Instance.ball.Hit(this, HitDirection, hitForce);
            if (OnHit != null)
            {
                OnHit.Invoke();
            }
        }
    }

    public void Serve()
    {
        print("Serve");
        Ball ball = Gameplay.Instance.ball;
        ball.transform.parent = null;
        ball.Hit(this, HitDirection, hitForce);
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