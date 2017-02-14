using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;
    private Rigidbody paddleRb;
    private Paddle bouncePaddle;

    public event Action OnHit;
    public event Action<Paddle> OnServe;
    public event Action<Paddle> OnScore;

    public Vector3 paddleV, paddlePrevPos;

    public float spinForce;

    public void Serve(Paddle paddle)
    {
        transform.parent = null;
        rigidbody.velocity = paddle.HitDirection * paddle.HitForce;
        bouncePaddle = paddle;
        if (OnServe != null)
        {
            OnServe.Invoke(paddle);
        }
    }

    void FixedUpdate()
    {

    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ScoringVolume")
        {
            Reset();
            if (OnScore != null)
            {
                OnScore.Invoke(bouncePaddle);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Paddle p = other.transform.GetComponent<Paddle>();
        if (p != null)
        {
            bouncePaddle = other.transform.GetComponent<Paddle>();
            rigidbody.AddForce(bouncePaddle.paddleVel.x / spinForce , bouncePaddle.paddleVel.y / spinForce , 0, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (bouncePaddle != null)
        {
            Debug.DrawLine(transform.position, bouncePaddle.transform.position, Color.green);
        }
    }
}