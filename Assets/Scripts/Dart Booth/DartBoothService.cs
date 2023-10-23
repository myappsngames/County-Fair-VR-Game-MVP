using System;
using UnityEngine;

public class DartBoothService : MonoBehaviour
{
    public event Action<float> TimerUpdated;

    [SerializeField] GameObject[] balloons;

    private int _balloonsPopped;

    public float Timer => _timer; // a one way read only access to _timer for DartBoothPresenter
    private float _timer;
    public bool IsTimerRunning => _isTimerRunning; // a one way read only access to _isTimerRunning for DartBoothPresenter
    private bool _isTimerRunning;

    private void Update()
    {
        // only increment timer if _isTimerRuning is set to true
        if (_isTimerRunning)
        {
            // for every frame in the update method, add the time elapsed between the last frame to _timer
            _timer += Time.deltaTime; // Time.deltaTime: time between frames
        } 
    }


    public void StartGame()
    {
        _isTimerRunning = true;
    }

    public void PopBalloon()
    {
        _balloonsPopped++;
        if (_balloonsPopped == balloons.Length)
        {
            PauseGame();
            // invoke event to subscribed listeners
            TimerUpdated?.Invoke(_timer);
        }
    }

    private void PauseGame()
    {
        _isTimerRunning = false;
    }

    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        _balloonsPopped = 0;
        _timer = 0;
        foreach (GameObject balloon in balloons)
        {
            balloon.gameObject.SetActive(true);
        }
    }
}
