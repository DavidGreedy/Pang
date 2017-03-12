using UnityEngine;

public class PaddleController : MonoBehaviour
{
    protected Paddle controlledPaddle;
    Vector3 paddlePosition = Vector3.forward * 5.0f;

    public Paddle ControlledPaddle
    {
        get { return controlledPaddle; }
    }

    private void OnDestroy()
    {
        if (controlledPaddle != null)
            Destroy(controlledPaddle.gameObject);
    }

    public void SetServer(Ball ball)
    {
        controlledPaddle.SetServer(ball);
    }

    public void GivePaddle(Paddle paddle)
    {
        controlledPaddle = paddle;
        paddle.transform.position = transform.position + paddlePosition;
    }
}