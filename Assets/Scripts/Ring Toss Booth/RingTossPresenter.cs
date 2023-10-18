using TMPro;
using UnityEngine;

public class RingTossPresenter : MonoBehaviour
{
    [SerializeField] TMP_Text TMP_ScoreText;
    private RingTossBoothService _ringTossBoothService;

    private void Start()
    {
        _ringTossBoothService = FindObjectOfType<RingTossBoothService>();
        if (_ringTossBoothService != null )
        {
            // Subscription to ScoreUpdated event to run OnScoreUpdated method
            _ringTossBoothService.ScoreUpdated += OnScoreUpdated;
        }
    }

    // Method for when ScoreUpdated Event is triggered; ScoreUpdated is triggering OnScoreUpdated
    private void OnScoreUpdated(int newScore)
    {
        TMP_ScoreText.text = "Score: " + newScore;
    }
}
