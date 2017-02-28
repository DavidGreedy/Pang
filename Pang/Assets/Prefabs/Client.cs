using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Client : MonoBehaviour {

    NetworkManager networkManager;

	// Use this for initialization
	void Start ()
    {
        networkManager = FindObjectOfType<NetworkManager>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConnectAsClient()
    {
        networkManager.StartClient();
    }
}
