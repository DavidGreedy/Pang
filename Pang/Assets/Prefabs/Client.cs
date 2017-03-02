using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Client : MonoBehaviour
{
    NetworkManager networkManager;

    void Start()
    {
        networkManager = FindObjectOfType<NetworkManager>();
        networkManager.StartHost();
    }

    public void ConnectAsClient()
    {
        networkManager.StartClient();
    }
}