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
        aiPlayerSpeed = GameManager.Instance.paddleDifficultyAmount;
	}

    void AIBehaviour()
    {
        Mathf.MoveTowards(this.transform.position.x, ballTarget.transform.position.x, aiPlayerSpeed);
        Mathf.MoveTowards(this.transform.position.y, ballTarget.transform.position.y, aiPlayerSpeed);
    }

}
