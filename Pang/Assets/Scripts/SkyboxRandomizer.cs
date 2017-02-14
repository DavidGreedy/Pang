using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRandomizer : MonoBehaviour {


    public Light ballLight;
    public Color[] ballLightColour;
    public Material[] ballMats;
    public GameObject ball;
    private MeshRenderer ballMesh;
    

    public int schemeNum;

	// Use this for initialization
	void Start ()
    {
        ballMesh = ball.GetComponent<MeshRenderer>();
        ChooseColourScheme();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseColourScheme()
    {
        schemeNum = Random.Range(0, ballMats.Length);
        switch(schemeNum)
        {
            case 0:
                ballLight.color = ballLightColour[schemeNum];
                ballMesh.material = ballMats[schemeNum];
            break;

            case 1:
                ballLight.color = ballLightColour[schemeNum];
                ballMesh.material = ballMats[schemeNum];
                break;

            case 2:
                ballLight.color = ballLightColour[schemeNum];
                ballMesh.material = ballMats[schemeNum];
                break;

            case 3:
                ballLight.color = ballLightColour[schemeNum];
                ballMesh.material = ballMats[schemeNum];
                break;

            case 4:
                ballLight.color = ballLightColour[schemeNum];
                ballMesh.material = ballMats[schemeNum];
                break;
        }
    }
}
