using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class NetworkSetup : NetworkManager
{
    public void OnClientConnect()
    {
        print("ClientConnected");
    }
}