using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public GameObject obstacleHolderObj;
    public ObstacleBehaviour[] obstacles;

    public float obstacleRate;
    public int obstaclesDifficulty;
    int currentActive;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(BeginObstacles());
    }

    public IEnumerator BeginObstacles()
    {
        while (GameState.Instance._gameMode == GameState.GameMode.Obstacle && !Gameplay.Instance.isPaused)
        {
            if (currentActive <= obstaclesDifficulty)
            {
                int random = Random.Range(0, 3);
                
            }
           
        }
        yield return new WaitForSeconds(obstacleRate);
    }
}
