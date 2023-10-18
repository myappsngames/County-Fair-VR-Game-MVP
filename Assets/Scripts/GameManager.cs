using System;
using UnityEngine;

// keep track of what the GameState is
public enum GameState // list of values you can select from; keep track of states
{
    Start,
    Play,
    Pause,
    Quit
}

public class GameManager : MonoBehaviour
{
    // turn Game Manager into a singleton
    public static GameManager instance;

    // event to notify listeners if GameState has changed
    public static event Action<GameState> OnGameStateChanged; // can be called from anywhere and trigger a change in GameState

    // encapsulate state of game; read only for use in playerBehavior.cs
    public GameState State => _state; // points to private variable _state
    // variable to know what the current GameState is
    private GameState _state;

    // check that no other GameManager exists
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateGameState(GameState.Start);
    }

    // method for updating the GameState
    public void UpdateGameState(GameState gameState)
    {
        // if gameState is equal to current gameState then return and do nothing
        if (_state == gameState) return;

        // if different than current game state, set _state to new gamestate
        _state = gameState;

        // check if game state is Quit state
        if (gameState == GameState.Quit)
        {
            HandleApplicationQuit();
        }

        // if there are listeners, invoke OnGameStateChanged with new gameState parameter
        OnGameStateChanged?.Invoke(gameState);
    }

    private void HandleApplicationQuit()
    {
        // if running in unity editor
        #if UNITY_EDITOR
            // end unity editor
            UnityEditor.EditorApplication.isPlaying = false;
        #else 
            // Quit application
            Application.Quit(); // Does not quit unity editor
        #endif
    }
}
