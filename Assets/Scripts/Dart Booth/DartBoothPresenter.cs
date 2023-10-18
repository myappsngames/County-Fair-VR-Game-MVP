using System;
using TMPro;
using UnityEngine;

public class DartBoothPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text TMP_Timer;

    private DartBoothService _dartBoothService;

    private void Start()
    {
        _dartBoothService = FindObjectOfType<DartBoothService>();
    }

    private void LateUpdate()
    {
        if (_dartBoothService.IsTimerRunning)
        {
            TMP_Timer.text = "Timer: " + TimeSpan.FromSeconds(_dartBoothService.Timer).ToString("mm\\:ss\\.fff");
        }
    }
}
