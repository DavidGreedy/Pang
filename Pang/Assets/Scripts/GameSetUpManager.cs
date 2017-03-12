using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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
        MENU = 0,
        COMPUTER = 1,
        ONLINE = 2,
        OBSTACLE = 3,
        RALLY = 4
    }

    public GameState _gameState;

    void Start()
    {
        _gameState = GameState.MENU;
    }

    public void SetState(int state)
    {
        _gameState = (GameState)state;
    }

    public void BeginGame()
    {
        switch (_gameState)
        {
            case GameState.MENU:
                LoadMenu();
                break;
            case GameState.COMPUTER:
                LoadOffline();
                break;
            case GameState.ONLINE:
                LoadOnline();
                break;
            case GameState.OBSTACLE:
                LoadObstacle();
                break;
            case GameState.RALLY:
                LoadRally();
                break;
        }
    }

    void LoadMenu()
    {
        Arena.SetActive(true);
    }

    void LoadOnline()
    {

    }

    void LoadOffline()
    {
        Gameplay.Instance.Begin();
        Gameplay.Instance.CreateAIOpponent();
    }

    public void SetTargetScore(Slider slider)
    {
        Debug.Log(string.Format("Target Score = {0}", (int)slider.value));
        Gameplay.Instance.targetScore = (int)slider.value;
    }

    public void SetDifficulty(Slider slider)
    {
        Debug.Log(string.Format("Difficulty = {0}", (int)slider.value));
        Gameplay.Instance.difficulty = (int)slider.value;
    }

    void LoadRally()
    {

    }

    void LoadObstacle()
    {

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

    //public void GivePaddle(bool isNetworked)
    //{
    //    PaddleController controller = Camera.main.GetComponent<PaddleController>();
    //    controller.enabled = true;
    //    controller.ControlledPaddle = Instantiate(paddlePrefab);
    //    if (isNetworked)
    //    {
    //        ClientScene.RegisterPrefab(controller.ControlledPaddle.gameObject);
    //    }
    //    controller.ControlledPaddle.Init();
    //    Gameplay.Instance.Begin();
    //}
}