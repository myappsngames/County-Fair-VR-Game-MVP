using UnityEngine;

public class PistolBehavior : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] float shootDistance = 10f; // 10 meters

    // field to control min and max pitch of sound
    [SerializeField] float minPitch = 0.9f;
    [SerializeField] float maxPitch = 1.1f;
    // field for audio source
    [SerializeField] private AudioSource _balloonPop;
    [SerializeField] private AudioSource _gunBlast;
    // field for balloon particles
    [SerializeField] private GameObject balloonPopParticles;

    private DartBoothService _dartBoothService;

    // Start is called before the first frame update
    void Start()
    {
        // access public methods in DartBoothService.cs
        _dartBoothService = FindObjectOfType<DartBoothService>();
    }

    public void gunBlast()
    {
        _gunBlast.pitch = Random.Range(minPitch, maxPitch);
        _gunBlast.PlayOneShot(_gunBlast.clip);
    }

    public void Shoot()
    {
        // get info from raycast
        RaycastHit hit;
        // if no colliders hit within 10 meters then return false, otherwise return true
        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, shootDistance))
        {
            // if collider has Balloon Tag, then deactivate balloon object (Pop Balloon)
            if(hit.transform.CompareTag("Balloon"))
            {
                // instantiate particles
                Instantiate(balloonPopParticles,
                hit.transform.position,
                hit.transform.rotation);

                // set balloon that is hit to false
                hit.transform.gameObject.SetActive(false);

                // varies the pitch
                _balloonPop.pitch = Random.Range(minPitch, maxPitch);    
                // PlayOneShot allows sound clip to finish
                _balloonPop.PlayOneShot(_balloonPop.clip);

                // keep track of popped balloons to end dart booth game
                _dartBoothService.PopBalloon();   
            }
        }
    }
}
