using System;
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

    public void SetScoresActive(bool state)
    {
        scoreText[0].transform.parent.gameObject.SetActive(state); // Sets the parent object of my score object to inactive
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void SetPaddle(Paddle paddle)
    {
        this.paddle = paddle;
    }

    public int Score()
    {
        return score;
    }

    void UpdateScoreText()
    {
        scoreText[0].text = score.ToString(); // My score
        scoreText[1].text = score.ToString(); // Their score
    }
}