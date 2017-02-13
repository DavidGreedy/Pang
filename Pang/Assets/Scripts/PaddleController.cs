using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Paddle controlledPaddle;

    void Update()
    {
        controlledPaddle.SetPosition((Vector3.ProjectOnPlane(transform.forward * controlledPaddle.PosZ, controlledPaddle.HitDirection) + (controlledPaddle.HitDirection * controlledPaddle.PosZ)));

        if (Input.GetMouseButton(0) && Gameplay.Instance.CurrentServer == controlledPaddle)
        {
            controlledPaddle.Serve();
        }
    }
}