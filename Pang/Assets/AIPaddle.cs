using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour {

    public GameObject ballTarget;


    public float aiPlayerSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        AIBehaviour();
        //aiPlayerSpeed = GameManager.Instance.paddleDifficultyAmount;
	}

    void AIBehaviour()
    {
        //if (GameState.Instance._gameState == GameState.CurrentGameState.Game)
        {
            if (Gameplay.matchPlaying)
            {
                {
                    if (ballTarget.transform.position.y > this.transform.position.y)
                        transform.Translate(new Vector3(0, aiPlayerSpeed, 0) * Time.deltaTime);

                    if (ballTarget.transform.position.y < this.transform.position.y)
                        transform.Translate(new Vector3(0, -aiPlayerSpeed, 0) * Time.deltaTime);

                    if (ballTarget.transform.position.x > this.transform.position.x)
                        transform.Translate(new Vector3(-aiPlayerSpeed, 0, 0) * Time.deltaTime);

                    if (ballTarget.transform.position.x < this.transform.position.x)
                        transform.Translate(new Vector3(aiPlayerSpeed, 0, 0) * Time.deltaTime);
                }
            }
        }
    }

}
