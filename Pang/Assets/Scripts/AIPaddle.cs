using UnityEngine;

public class AIPaddle : PaddleController
{
    public Ball targetBall;

    private void Init()
    {
        controlledPaddle.Speed = Gameplay.Instance.difficulty;
        controlledPaddle.OnSetServe += BeginServe;
    }

    void Update()
    {
        Vector2 dir = targetBall.transform.position - transform.position;
        Vector2 nextPos = (Vector2)transform.position + (dir.normalized * Time.deltaTime * 2.0f);

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