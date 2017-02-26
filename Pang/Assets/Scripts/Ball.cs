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

    private bool isActive = false;

    public float maxSpin;

    public float spinModifier = 10f;


    [SerializeField]
    private LineController.ColorScheme colorScheme;

    [SerializeField]
    private Renderer[] renderers;

    private void Start()
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = LineController.Instance.GetColor(colorScheme);
            renderers[i].material.SetColor("_EmissionColor", LineController.Instance.GetColor(colorScheme));
            DynamicGI.SetEmissive(renderers[i], LineController.Instance.GetColor(colorScheme) * 4f);
            DynamicGI.UpdateMaterials(renderers[i]);
        }
        DynamicGI.UpdateEnvironment();
    }

    public void Serve(Paddle paddle)
    {
        transform.parent = null;
        rigidbody.velocity = (paddle.HitDirection * paddle.HitForce) + (Vector3)(Vector2.ClampMagnitude(paddle.Velocity, maxSpin) * spinModifier);
        bouncePaddle = paddle;
        isActive = true;
        if (OnServe != null)
        {
            OnServe.Invoke(paddle);
        }
    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        isActive = false;
    }

    void Update()
    {
        if (isActive)
        {
            rigidbody.AddForce(-(Vector2)transform.position.normalized * spinModifier * 0.2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ScoringVolume")
        {
            Reset();
            Goal g = other.GetComponent<Goal>();
            g.whoGetsPoint.AddScore(1);
            if (OnScore != null)
            {
                OnScore.Invoke(g.whoGetsPoint);
            }
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