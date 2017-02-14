using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Paddle controlledPaddle;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "PaddleWall")
                controlledPaddle.transform.position = hit.point + (Vector3.forward * 0.1f);
            //This works but the ray doesn't move with the rotation of the camera? No fuckign clue why probably a shitty VR reason
        }
        Debug.DrawLine(transform.position, hit.point, Color.red);

        //Original Method
        //controlledPaddle.SetPosition((Vector3.ProjectOnPlane(transform.forward * controlledPaddle.PosZ, controlledPaddle.HitDirection) + (controlledPaddle.HitDirection * controlledPaddle.PosZ)));

        if (Input.GetMouseButtonDown(0))
        {
            controlledPaddle.Serve();
        }
    }
}