using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEditor;

public partial class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameState CurrentGameState;
    [SerializeField] private GameScene CurrentGameScene;

    //[SerializeField] private SceneAsset MainMenu;
    //[SerializeField] private SceneAsset InGame;

    /*public void ChangeState(GameState state)
    {
        CurrentGameState = state;

        switch (CurrentGameState)
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
    }*/

    public void ChangeScene(int gameScene)
    {
        /*int sceneName;
        switch(gameScene)
        {
            case GameScene.Menu:
                //sceneName = MainMenu.name;
                ChangeState(GameState.Menu);
                break;
            case GameScene.InGame:
                //sceneName = InGame.name;
                ChangeState(GameState.PlayingLevel);
                break;
        }
        */
        SceneManager.LoadScene(gameScene);
    }

    //public void ChangeSceneToMenu() => ChangeScene(GameScene.Menu);
    public void ChangeSceneToInGame() => ChangeScene(1);
}