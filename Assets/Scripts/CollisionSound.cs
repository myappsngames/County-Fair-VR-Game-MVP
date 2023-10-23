using UnityEngine;

// Require AudioSource to use this script
[RequireComponent (typeof(AudioSource))]

public class CollisionSound : MonoBehaviour
{
    // field to change tags
    [SerializeField] private string objectTag;

    // field to control min and max pitch of sound
    [SerializeField] float minPitch = 0.9f;
    [SerializeField] float maxPitch = 1.1f;

    // variable for audio source
    [SerializeField] AudioSource _audioSource;

    private void Awake()
    {
        // get audio source
        _audioSource = GetComponent<AudioSource>();
    }

    // event for detecting collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(objectTag))
        {
            // varies the pitch
            _audioSource.pitch = Random.Range(minPitch, maxPitch);
            // PlayOneShot allows sound clip to finish
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}
