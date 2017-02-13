using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;

    private Paddle bouncePaddle;

    public event Action OnHit;
    public event Action<Paddle> OnServe;
    public event Action<Paddle> OnScore;

    public Vector3 spinAxis;
    public Vector3 spinVector;
    public float spinForce;
    public float spinDecay;

    private bool isFree;

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
        if (isFree)
        {
            //Vector3 spinStrength = spinAxis - transform.position;
            //spinVector.z = 0;
            //rigidbody.AddForce((spinVector + spinStrength) * Time.deltaTime, ForceMode.Force);
            //spinVector -= spinVector * spinDecay;
        }
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