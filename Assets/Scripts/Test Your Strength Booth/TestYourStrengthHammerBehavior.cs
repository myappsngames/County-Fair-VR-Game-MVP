using UnityEngine;

public class TestYourStrengthHammerBehavior : MonoBehaviour
{
    public float StrikeMultiplier => strikeMultiplier; // encapsulation; read only
    [SerializeField] private float strikeMultiplier = 0.02f;

    [SerializeField] private Transform centerOfMass;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // set center of mass of rigidbody to the position of Center of Mass game object
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }
}
