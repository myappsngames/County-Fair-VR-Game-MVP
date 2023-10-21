using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    // make singleton
    public static PrizeManager Instance;

    [SerializeField] private int ringTossPrizeScore = 20;
    [SerializeField] private GameObject ringTossTicketPrefab;
    [SerializeField] private Transform ringTossTicketSpawnPoint;
    // variable to confirm ticket was instantiated
    [SerializeField] private bool hasSpawnedRingTossTicket;

    // variable to access RingTossBoothService.cs for score
    private RingTossBoothService _ringTossBoothService;

    private void Awake()
    {
        // Checks entire scene if there is another PrizeManager Instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        // Service locator pattern
        _ringTossBoothService = FindObjectOfType<RingTossBoothService>();
        // subscribe to ScoreUpdated event; if score updates, run HandleRingTossScoreChange
        _ringTossBoothService.ScoreUpdated += HandleRingTossScoreChange;
    }


    private void OnDestroy()
    {
        // unsubcribe to event
        _ringTossBoothService.ScoreUpdated -= HandleRingTossScoreChange;
    }

    private void HandleRingTossScoreChange(int newScore)
    {
        // if ticket has not been instantiated and newscore is greater than or equal to prize score
        if (!hasSpawnedRingTossTicket && newScore >= ringTossPrizeScore)
        {
            // Instantiate ticket
            Instantiate(
                ringTossTicketPrefab, 
                ringTossTicketSpawnPoint.position, 
                ringTossTicketSpawnPoint.rotation);
            // confirm ticket has been instantiated
            hasSpawnedRingTossTicket = true;

            // spawn UI

            // spawn Achievement
        }
    }
}
