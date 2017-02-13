using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;

    private Paddle bouncePaddle;

    public event Action<Paddle> OnHit;
    public event Action OnScore;

    public event Action OnSpawn;

    public void Spawn(Paddle paddle)
    {
        paddle.Serve();
    }

    public void Spawn(Vector3 position, Vector3 direction, float speed)
    {
        transform.position = position;
        rigidbody.AddForce(direction * speed, ForceMode.Impulse);
    }

    public void Hit(Paddle paddle, Vector3 direction, float force)
    {
        bouncePaddle = paddle;
        rigidbody.velocity = direction * force;
        if (OnHit != null)
        {
            OnHit.Invoke(paddle);
        }
    }

    public void Score(int score)
    {
        bouncePaddle.ScoreObject.AddScore(score);
        rigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ScoringVolume")
        {
            Score(1);
        }
    }
}