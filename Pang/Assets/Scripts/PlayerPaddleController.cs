using UnityEngine;

public class PlayerPaddleController : PaddleController
{
    public LayerMask raycastLayer;

    private void Start()
    {

    }

    void Update()
    {
        if (controlledPaddle != null)
        {
            RaycastHit hit;
            Ray lookRay = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(lookRay, out hit, Mathf.Infinity, raycastLayer))
            {
                if (hit.collider.tag == "PaddleWall")
                    controlledPaddle.SetPosition(hit.point);
            }
            Debug.DrawLine(transform.position, hit.point, Color.red);

            //Original Method
            //controlledPaddle.SetPosition((Vector3.ProjectOnPlane(transform.forward * controlledPaddle.PosZ, controlledPaddle.HitDirection) + (controlledPaddle.HitDirection * controlledPaddle.PosZ)));

            if (Input.GetMouseButtonDown(0))
            {
                controlledPaddle.Serve();
                print("SERVED");
            }
        }
    }
}