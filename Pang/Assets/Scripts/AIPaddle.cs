using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public GameObject ballTarget;

    public bool boostTokenActive;
    public int boostTokensRemaining;

    public Paddle controlledPaddle;

    private void Awake()
    {
        boostTokensRemaining = GameManager.boostTokenAmt;
        controlledPaddle.Speed = GameManager.paddleSpeed;
    }

    void Start()
    {
        controlledPaddle.OnSetServe += BeginServe;
    }

    void Update()
    {
        AIBehaviour();
    }

    void AIBehaviour()
    {
        Vector3 dir = ballTarget.transform.position - transform.position;
        Vector3 nextPos = transform.position + dir.normalized * Time.deltaTime * 20.0f;

        controlledPaddle.SetPosition(nextPos);
    }

    void BeginServe()
    {
        Invoke("Serve", 2f);
    }

    void Serve()
    {
        controlledPaddle.Serve();
    }
}