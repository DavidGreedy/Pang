using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    [Range(0, 10f)]
    public int paddleDifficultyAmount;

    [Range(5, 20f)]
    public static int targetScore;

	// Use this for initialization
	void Start ()
    {
        targetScore = 5;
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
