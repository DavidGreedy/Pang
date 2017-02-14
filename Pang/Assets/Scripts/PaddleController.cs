using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Paddle controlledPaddle;
    public GameObject rayOrigin;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin.transform.position, Vector3.forward, out hit))
        {
            if(hit.collider.tag == "PaddleWall")
            controlledPaddle.transform.position = hit.point;
            //This works but the ray doesn't move with the rotation of the camera? No fuckign clue why probably a shitty VR reason
        }
        Debug.DrawRay(rayOrigin.transform.position, Vector3.forward, Color.red);

        //Original Method
        //controlledPaddle.SetPosition((Vector3.ProjectOnPlane(transform.forward * controlledPaddle.PosZ, controlledPaddle.HitDirection) + (controlledPaddle.HitDirection * controlledPaddle.PosZ)));

        if (Input.GetMouseButtonDown(0))
        {
            controlledPaddle.Serve();
        }


    }
}