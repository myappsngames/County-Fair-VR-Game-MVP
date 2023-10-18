using UnityEngine;

public class PistolBehavior : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] float shootDistance = 10f; // 10 meters

    private DartBoothService _dartBoothService;

    // Start is called before the first frame update
    void Start()
    {
        // access public methods in DartBoothService.cs
        _dartBoothService = FindObjectOfType<DartBoothService>();
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
                // set balloon that is hit to false
                hit.transform.gameObject.SetActive(false);
                _dartBoothService.PopBalloon();
            }
        }
    }
}
