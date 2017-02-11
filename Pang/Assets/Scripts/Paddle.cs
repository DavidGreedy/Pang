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

    public event Action OnHit;

    private Vector3 targetPosition;

    public Vector3 ServePosition
    { get { return transform.position + HitDirection; } }

    private void Start()
    {
        transform.forward = hitDir;
        OnHit += DrawBounceVel;
        Gameplay.Instance.AddPaddle(this);
        Gameplay.Instance.OnServe += Serve;
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
        Debug.DrawLine(transform.position, targetPosition, Color.magenta);
        yield return new WaitForSeconds(3f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            print(1);
            Gameplay.Instance.ball.Hit(this);
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
        ball.Hit(this);
    }

    public void SetServer(Ball ball)
    {
        print(gameObject.name + " IS SERVING");
        ball.transform.position = ServePosition;
        ball.transform.parent = transform;
    }
}