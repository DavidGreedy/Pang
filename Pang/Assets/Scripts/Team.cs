using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [SerializeField]
    private int teamNumber = 0;

    [SerializeField]
    private int score = 0;

    public int TeamNumber
    {
        get { return teamNumber; }
    }

    public int Score
    {
        get { return score; }
    }
}