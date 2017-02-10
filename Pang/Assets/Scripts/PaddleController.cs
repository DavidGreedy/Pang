using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GVR;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    GameObject paddleGameObject;

    [SerializeField]
    float paddleDistance;

    [SerializeField]
    Vector3 paddleFaceDir = Vector3.forward;

    void Start()
    {

    }

    void Update()
    {
        paddleGameObject.transform.position = Vector3.ProjectOnPlane(transform.forward * paddleDistance, paddleFaceDir) + (paddleFaceDir * paddleDistance);
        paddleGameObject.transform.forward = paddleFaceDir;
    }
}
