using System;
using UnityEngine;
using UnityEngine.Networking;

public class Ball : NetworkBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;
    private Paddle bouncePaddle;

    public event Action OnHit;
    public event Action<Paddle> OnServe;
    public event Action<Paddle> OnScore;

    private bool isActive = false;

    public float maxSpin;

    public float spinModifier = 10f;

    [SerializeField]
    private LineController.ColorScheme colorScheme;

    [SerializeField]
    private Renderer[] renderers;

    private Vector2 spinTarget = Vector2.zero;

    public void Serve(Paddle paddle)
    {
        transform.parent = null;
        rigidbody.velocity = (paddle.HitDirection * paddle.HitForce) + (Vector3)(Vector2.ClampMagnitude(paddle.Velocity, maxSpin) * spinModifier);
        bouncePaddle = paddle;
        isActive = true;
        rigidbody.isKinematic = false;
        if (OnServe != null)
        {
            OnServe.Invoke(paddle);
        }
    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.isKinematic = true;
        isActive = false;
    }

    void Update()
    {
        if (isActive)
        {
            rigidbody.AddForce(spinTarget - (Vector2)transform.position.normalized * spinModifier * 0.2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ScoringVolume")
        {
            print("BALL ENTERED GOAL");
            Goal g = other.GetComponent<Goal>();
            g.whoGetsPoint.AddScore(1);
            Reset();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Paddle p = other.transform.GetComponent<Paddle>();
        if (p != null)
        {
            bouncePaddle = other.transform.GetComponent<Paddle>();
            rigidbody.AddForce(((Vector2)bouncePaddle.Velocity * spinModifier * 10f));
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (bouncePaddle != null)
        {
            //Debug.DrawLine(transform.position, bouncePaddle.transform.position, Color.green);
        }
    }
}