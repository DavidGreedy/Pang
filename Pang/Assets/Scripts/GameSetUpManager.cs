using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameSetUpManager : Singleton<GameSetUpManager>
{
    //Menu gameObjects
    public GameObject menuObj, menuPlayer;

    //Needed for every gameMode
    public GameObject Arena, ball, playerPaddle;

    //Needed for SinglePlayer, Obstacle and rally modes
    public GameObject AIPlayer;

    //Needed for obstacle mode
    public GameObject obstacleArena, obstacleHolder;

    public bool ifHost;

    public int playerNum;

    [SerializeField]
    private Paddle paddlePrefab;

    //Switch state to load in appropriate objects
    public enum GameState
    {
        Menu,
        OfflineMatch,
        OnlineMatch,
        Obstacle,
        Rally
    }

    public GameState _gameState;
    // Use this for initialization
    void Start()
    {
        _gameState = GameState.Menu;
        SwitchState();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(int stateNum)
    {
        switch (stateNum)
        {
            case 0:
                _gameState = GameState.Menu;
                SwitchState();
                break;
            case 1:
                _gameState = GameState.OfflineMatch;
                SwitchState();
                break;
            case 2:
                _gameState = GameState.OnlineMatch;
                SwitchState();
                break;
            case 3:
                _gameState = GameState.Obstacle;
                SwitchState();
                break;
            case 4:
                _gameState = GameState.Rally;
                SwitchState();
                break;
        }
    }

    public void SwitchState()
    {
        switch (_gameState)
        {
            case GameState.Menu:
                LoadMenu();
                break;
            case GameState.OfflineMatch:
                LoadOfflineMatch();
                break;
            case GameState.OnlineMatch:
                LoadOnlineMatch();
                break;
            case GameState.Obstacle:
                LoadObstacleMatch();
                break;
            case GameState.Rally:
                LoadRallyMatch();
                break;
        }
    }

    void LoadMenu()
    {
        menuObj.SetActive(true);
        //menuPlayer.SetActive(true);
        Arena.SetActive(true);
    }

    void LoadOnlineMatch()
    {
        menuObj.SetActive(false);
        menuPlayer.SetActive(false);
        GivePaddle(true);
    }

    void LoadOfflineMatch()
    {
        menuObj.SetActive(false);
        menuPlayer.SetActive(false);
        GivePaddle(false);
    }

    void LoadRallyMatch()
    {
        menuObj.SetActive(false);
        menuPlayer.SetActive(false);
    }

    void LoadObstacleMatch()
    {
        menuObj.SetActive(false);
        menuPlayer.SetActive(false);
    }

    public void HostTrue()
    {
        ifHost = true;
        playerNum = 1;
    }

    public void HostFalse()
    {
        ifHost = false;
        playerNum = 0;
    }

    public void ClientTrue()
    {
        ifHost = true;
        playerNum = 2;
    }

    public void ClientFalse()
    {
        ifHost = false;
        playerNum = 0;
    }

    public void GivePaddle(bool isNetworked)
    {
        PaddleController controller = Camera.main.GetComponent<PaddleController>();
        controller.enabled = true;
        controller.controlledPaddle = Instantiate(paddlePrefab);
        if (isNetworked)
        {
            ClientScene.RegisterPrefab(controller.controlledPaddle.gameObject);
        }
        controller.controlledPaddle.Init();
        Gameplay.Instance.Begin();
    }
}