using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : Singleton<GameState>
{
    public enum CurrentGameState { Menu, Pause, Game };
    public CurrentGameState _gameState;
}