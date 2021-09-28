using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Control de estados del juego.
    public enum GameState
    {
        MainMenu,
        InGame,
        Pause,
        GameOver,
        StartingGame
    }

    private GameState _actualGameState;
    public GameState actualGameState
    {
        get
        {
            return actualGameState;
        }
    }

    // Para controlar las escenas de una manera practica.
    public enum GameScenes
    {
        MainMenu = 0,
        Nivel1 = 1,
        Nivel2 = 2,
        Nivel3 = 3,
        Nivel4 = 4,
        Nivel5 = 5,
        Nivel6 = 6
    }

    // Player actual
    public GameObject actualPlayer;

    // Cursor in game
    public Texture2D inGameCursor;

    // Singleton
    private static GameManager _sharedInstance = null;

    public static GameManager sharedInstance
    {
        get
        {
            return _sharedInstance;
        }
    }

    private void Awake()
    {
        if (_sharedInstance != null && _sharedInstance != this)
        {
            Destroy(gameObject);
            return;
        }

        _sharedInstance = this;
        DontDestroyOnLoad(this);
    }

    public void ChangeGameState(GameState newGameState)
    {
        _actualGameState = newGameState;

        switch (_actualGameState)
        {
            case GameState.MainMenu:
                break;
            case GameState.Pause:
                break;
            case GameState.StartingGame:
                break;
            case GameState.InGame:
                //Cursor.SetCursor(InGameCursor, Vector2.zero, CursorMode.Auto);
                break;
            case GameState.GameOver:
                //Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                break;
        }
    }

    public void ChangeScene(GameScenes scene)
    {
        ChangeGameState(GameState.StartingGame);
        SceneManager.LoadScene((int)scene);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
