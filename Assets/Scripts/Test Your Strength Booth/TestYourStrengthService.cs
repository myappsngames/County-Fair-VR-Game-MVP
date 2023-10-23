using System;
using System.Collections;
using UnityEngine;

public class TestYourStrengthService : MonoBehaviour
{
    // event for updated slider height
    public event Action<float> sliderHeightUpdated;

    // Slider
    [SerializeField] private Transform slider;
    [SerializeField] private float maxHeight = 6.63f;
    [SerializeField] private float sliderDuration = 1f;

    private float _initialSliderHeight;
    private bool _isSliderMoving;


    private void Start()
    {
        _initialSliderHeight = slider.localPosition.y; //scalable way of getting y position
    }
    public void Strike(float mass, float velocity, float strikeMultiplier)
    {
        Debug.Log("Strike! With a mass of " + mass
            + " and a velocity of " + velocity
            + " and a multiplier of " + strikeMultiplier);

        // physics calculation
        float impactForce = mass * velocity;

        // move the slider
        float sliderHeight = Mathf.Clamp(impactForce * strikeMultiplier,
            _initialSliderHeight,
            maxHeight); // Clamp: Restrain between two values

        // check if slider is already moving; if not, then initiate movement by calling a MoveSlider Coroutine
        if (!_isSliderMoving)
        {
            StartCoroutine(MoveSlider(sliderHeight));
        }
    }

    private IEnumerator MoveSlider(float targetHeight)
    {
        // set _isSliderMoving to true
        _isSliderMoving = true;

        // setup starting and ending positions
        Vector3 startPos = new Vector3(
            slider.localPosition.x, 
            _initialSliderHeight, 
            slider.localPosition.z);
        Vector3 endPos = new Vector3(
            slider.localPosition.x,
            targetHeight,
            slider.localPosition.z);

        // Move slider up
        float elapsedTime = 0f; // counter to keep track of sliderDuration
        while (elapsedTime < sliderDuration)
        {
            // lerp: gradually move from one position to another
            slider.localPosition = Vector3.Lerp(startPos, endPos, elapsedTime / sliderDuration);
            elapsedTime += Time.deltaTime;
           
            // call event to notify PrizeManager
            sliderHeightUpdated?.Invoke(targetHeight);
            yield return null;
        }

        // Pause slider
        yield return new WaitForSeconds(sliderDuration);

        // Move slider down
        elapsedTime = 0f; // set elapsedTime back to zero
        while (elapsedTime < sliderDuration)
        {
            // lerp: gradually move from one position to another
            slider.localPosition = Vector3.Lerp(endPos, startPos, elapsedTime / sliderDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // set _isSliderMoving to false
        _isSliderMoving = false;
    }
}
