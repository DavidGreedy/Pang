using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public GameObject ballTarget;
    public float aiPlayerSpeed;

    public bool boostTokenActive;
    public int boostTokensRemaining;

    public Paddle controlledPaddle;

    private void Awake()
    {
        boostTokensRemaining = GameManager.boostTokenAmt;
        controlledPaddle.Speed = GameManager.paddleSpeed;
    }

    void Update()
    {
        AIBehaviour();
        //aiPlayerSpeed = GameManager.Instance.paddleDifficultyAmount;
    }

    void AIBehaviour()
    {
        //TODO: Repair this
    }

    void Serve()
    {
        controlledPaddle.Serve();
    }
}