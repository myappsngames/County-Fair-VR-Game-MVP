using System;
using UnityEngine;

public class RingTossBoothService : MonoBehaviour
{
    // Need to keep track of score
    // Need a method that adds to the score from RingTossRingBehavior.cs

    public event Action<int> ScoreUpdated;

    // reference to list of rings
    [SerializeField] private GameObject[] rings;

    [SerializeField] private int scoreToAdd = 10;


    private int _score;
    // Variables used to reset rings back to starting positions & rotations
    private Vector3[] _ringStartingPositions;
    private Quaternion[] _ringStartingRotations;

    private void Start()
    {
        // new empty arrays for position and rotation data
        _ringStartingPositions = new Vector3[rings.Length];
        _ringStartingRotations = new Quaternion[rings.Length];

        for (int i = 0; i < rings.Length; i++) 
        {
            _ringStartingPositions[i] = rings[i].transform.position;
            _ringStartingRotations[i] = rings[i].transform.rotation;
        }
    }

    public void AddToScore()
    {
        // add and update the score
        _score += scoreToAdd;
        // event that other scripts can subscribe to when score has been updated; broadcasts the score whenever the score changes
        ScoreUpdated?.Invoke(_score); // if none are subscribed, even is not invoked
    }

    // Method for reseting the game
    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        // for every ring in list, get ring transform and set position and rotation back to starting values
        for (int i = 0;i < rings.Length;i++)
        {
            rings[i].transform.SetPositionAndRotation(
                _ringStartingPositions[i], 
                _ringStartingRotations[i]);
        }
        // reset score to 0
        _score = 0;
        ScoreUpdated?.Invoke(_score); // necessary becuase score is also updated when reseting game
    }
}
