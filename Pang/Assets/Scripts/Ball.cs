using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;

    private Paddle bouncePaddle;

    public event Action<Paddle> OnHit;
    public event Action OnSpawn;

    private bool isInPlay;

    public bool IsInPlay
    {
        get { return isInPlay; }
    }

    public void Spawn(Paddle paddle)
    {
        paddle.Serve();
    }

    public void Spawn(Vector3 position, Vector3 direction, float speed)
    {
        transform.position = position;
        rigidbody.AddForce(direction * speed, ForceMode.Impulse);

    }

    public void Hit(Paddle paddle)
    {
        bouncePaddle = paddle;
        if (transform.parent == paddle.transform)
        {
            transform.parent = null;
        }
        rigidbody.AddForce(paddle.HitDirection * paddle.Speed, ForceMode.Impulse);
    }
}