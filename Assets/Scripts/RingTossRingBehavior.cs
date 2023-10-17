using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossRingBehavior : MonoBehaviour
{
    private bool _isAroundBottle; // false
    // create RingTossBoothService object for script linking
    private RingTossBoothService _ringTossBoothService;
    void Start()
    {
        // gain access to RingTossBoothService
        _ringTossBoothService = FindObjectOfType<RingTossBoothService>(); // expensive; not efficient // Service Locator Pattern is better
    }

    // Method that detects if ring trigger collides with bottle
    private void OnTriggerEnter(Collider other)
    {
        // if touching a bottle
        if (other.gameObject.CompareTag("Bottle"))
        {
            // then set _isAroundBottle to true
            _isAroundBottle = true;
            // Stop all Coroutines before starting new one to avoid adding multiple scores; ex. 30 pts instead of 10 pts
            StopAllCoroutines();
            // And start Coroutine
            StartCoroutine(ScoreDelay());

        }
    }

    // Method that detects if ring bounces out of bottle
    private void OnTriggerExit(Collider other)
    {
        // if trigger exit collision was with bottle
        if (other.gameObject.CompareTag("Bottle"))
        {   // then set _isAroundBottle to false
            _isAroundBottle = false;
        }
    }

    // Coroutine with 3 second delay
    private IEnumerator ScoreDelay()
    {
        // Wait for 3 Seconds to check if ring is around bottle
        yield return new WaitForSeconds(3f);
        // if ringTossBoothService is in the scene &&
        // if ring is around bottle after 3 seconds then add to score
        if (_ringTossBoothService != null && _isAroundBottle)
        {
            _ringTossBoothService.AddToScore();
        }

    }
}
