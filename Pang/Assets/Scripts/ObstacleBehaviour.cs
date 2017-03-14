using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 goalPos;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update() {

    }

    public void EnterArena()
    {
        Vector3.MoveTowards(startPos, goalPos, 0.1f);
    }

    public void ExitArena()
    {
        Vector3.MoveTowards(goalPos, startPos, 0.1f);
    }
}
