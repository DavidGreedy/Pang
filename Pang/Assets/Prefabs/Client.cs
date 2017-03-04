using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Client : MonoBehaviour
{
    NetworkManager networkManager;
    public bool twoPlayers;
    public int playerCount;

    void Start()
    {
        networkManager = FindObjectOfType<NetworkManager>();
        networkManager.StartHost();
    }

    public void ConnectAsClient()
    {
        networkManager.StartClient();
    }

    void OnPlayerConnected(NetworkPlayer player)
    {
        playerCount++;
        CheckPlayerCount();
    }

    void OnPlayerDisonnected(NetworkPlayer player)
    {
        playerCount++;
        CheckPlayerCount();
    }

    void CheckPlayerCount()
    {
        if (playerCount == 2)
        {
            twoPlayers = true;
        }
        else if (playerCount < 2)
        {
            twoPlayers = false;
        }
    }

}