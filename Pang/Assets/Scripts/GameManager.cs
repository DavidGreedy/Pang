using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static int paddleSpeed, targetScore, boostTokenAmt;
    public static float paddleScale;

    public enum GameDiff { Normal, Hard }
    public static GameDiff _gameDiff;

    void Start()
    {
        targetScore = 5;
        DontDestroyOnLoad(this);
    }

    public void SetUp(int _gameMode)
    {
        switch (_gameMode)
        {
            case 0:
                _gameDiff = GameDiff.Normal;
                paddleSpeed = 10;
                boostTokenAmt = 10;
                paddleScale = 1;
                break;

            case 1:
                _gameDiff = GameDiff.Hard;
                paddleSpeed = 10;
                boostTokenAmt = 5;
                paddleScale = 0.5f;
                break;
        }
    }
}