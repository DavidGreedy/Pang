using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Team : MonoBehaviour
{
    [SerializeField]
    private int teamNumber;

    private int score;

    [SerializeField]
    private Text[] scoreText;

    public Paddle paddle;

    public Text[] ScoreText
    {
        get { return scoreText; }
    }

    public void SetScoresActive(bool state)
    {
        scoreText[0].transform.parent.gameObject.SetActive(state);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Gameplay.Instance.ScoreEvent(this);
    }


    public void SetPaddle(Paddle paddle)
    {
        this.paddle = paddle;
    }

    public int Score()
    {
        return score;
    }
}