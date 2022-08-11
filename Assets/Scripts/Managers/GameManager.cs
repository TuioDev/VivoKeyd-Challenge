using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameState currentGameState;

    public void ChangeState(GameState state)
    {
        currentGameState = state;

        switch (currentGameState)
        {
            case GameState.Menu:
                break;
            case GameState.Overworld:
                break;
            case GameState.Store:
                break;
            case GameState.PlayingLevel:
                break;
            case GameState.Paused:
                break;
            default:
                break;
        }
    }
}