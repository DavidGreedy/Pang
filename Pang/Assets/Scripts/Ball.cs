using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;

    private Paddle bouncePaddle;

    public event Action OnHit;
    public event Action OnServe;
    public event Action OnScore;

    public Vector3 spinAxis;
    public Vector3 spinVector;
    public float spinForce;
    public float spinDecay;

    public void Hit(Paddle paddle)
    {
        bouncePaddle = paddle;
    }

    public void Serve(Paddle paddle)
    {
        rigidbody.velocity = paddle.HitDirection * paddle.HitForce;
    }

    void FixedUpdate()
    {
        Vector3 spinStrength = spinAxis - transform.position;
        spinVector.z = 0;
        rigidbody.AddForce((spinVector + spinStrength) * Time.deltaTime, ForceMode.Force);
        spinVector -= spinVector * spinDecay;
    }

    public void Score(int score)
    {
        rigidbody.velocity = Vector3.zero;
        bouncePaddle.ScoreObject.AddScore(score);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ScoringVolume")
        {
            Score(1);
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