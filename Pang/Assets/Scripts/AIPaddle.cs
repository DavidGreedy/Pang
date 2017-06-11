using UnityEngine;

public class AIPaddle : PaddleController
{
    public Ball targetBall;
    private float speed;
    public void Init(Paddle paddle, Ball ball, int difficulty)
    {
        controlledPaddle = paddle;
        controlledPaddle.transform.position = new Vector3(controlledPaddle.transform.position.x, 0, 9.8f);
        speed = difficulty;
        controlledPaddle.OnSetServe += BeginServe;
        targetBall = ball;
    }

    void Update()
    {
        if (targetBall != null)
        {
            Vector2 dir = targetBall.transform.position - transform.position;
            Vector2 nextPos = (Vector2)transform.position + (dir.normalized * Time.deltaTime * speed * 0.2f);
            controlledPaddle.SetPosition(nextPos);
        }
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