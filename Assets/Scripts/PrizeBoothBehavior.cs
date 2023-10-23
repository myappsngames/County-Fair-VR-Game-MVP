using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrizeBoothBehavior : MonoBehaviour
{
    [SerializeField] public XRSocketInteractor _socketInteractor;
    [Header("Tickets")]
    [SerializeField] public GameObject ringTossBoothTicket;
    [SerializeField] public GameObject testYourStrengthBoothTicket;
    [SerializeField] public GameObject dartBoothTicket;

    [Header("Prizes")]
    [SerializeField] public GameObject RingTossBoothPrizePrefab;
    [SerializeField] public Transform RingTossBoothPrizeSpawnPoint;

    [SerializeField] public GameObject TestYourStrengthPrizePrefab;
    [SerializeField] public Transform TestYourStrengthPrizeSpawnPoint;

    [SerializeField] public GameObject DartBoothPrizePrefab;
    [SerializeField] public Transform DartBoothPrizeSpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        _socketInteractor = GetComponent<XRSocketInteractor>();
    }

    public void SpawnRingTossBoothPrize() // Pink
    {
        Instantiate(
                RingTossBoothPrizePrefab,
                RingTossBoothPrizeSpawnPoint.position,
                RingTossBoothPrizeSpawnPoint.rotation);
    }

    public void SpawnTestYourStrengthBoothPrize() // Yellow
    {
        Instantiate(
                TestYourStrengthPrizePrefab,
                TestYourStrengthPrizeSpawnPoint.position,
                TestYourStrengthPrizeSpawnPoint.rotation);
    }


    public void SpawnDartBoothPrize() // Green
    {
        Instantiate(
                DartBoothPrizePrefab,
                DartBoothPrizeSpawnPoint.position,
                DartBoothPrizeSpawnPoint.rotation);
    }
}
