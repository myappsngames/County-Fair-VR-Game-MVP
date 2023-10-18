using UnityEngine;

public class TestYourStrengthStrikePadBehavior : MonoBehaviour
{
    private TestYourStrengthService _testYourStrengthService;

    private void Start()
    {
        _testYourStrengthService = FindObjectOfType<TestYourStrengthService>(); // looks for anything in the scene with a TestYourStrengthService attached to it
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hammer"))
        {
            // get the hammer Rigidbody data
            var hammerRigidbody = collision.gameObject.GetComponentInParent<Rigidbody>();
            // get hammerBehavior data
            var hammerBehavior = collision.gameObject.GetComponentInParent<TestYourStrengthHammerBehavior>();
            // call strike method
            _testYourStrengthService.Strike(
                hammerRigidbody.mass, 
                collision.relativeVelocity.magnitude, 
                hammerBehavior.StrikeMultiplier);
        }
    }
}
