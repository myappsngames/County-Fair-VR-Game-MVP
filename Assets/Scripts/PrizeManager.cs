using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    // make singleton
    public static PrizeManager Instance;

    [Header("Ring Toss Booth")]
    [SerializeField] private GameObject ringTossBoothTicketPrefab;
    [SerializeField] private Transform ringTossBoothTicketSpawnPoint;
    [SerializeField] private int ringTossBoothPrizeScore = 20;
    [SerializeField] private bool hasSpawnedRingTossBoothTicket;
    // variable to access RingTossBoothService.cs for score
    private RingTossBoothService _ringTossBoothService;

    [Header("Test Your Strength Booth")]
    [SerializeField] private GameObject testYourStrengthBoothTicketPrefab;
    [SerializeField] private Transform testYourStrengthBoothTicketSpawnPoint;
    [SerializeField] private float TestYourStrengthBoothPrizeScore = 6.63f;
    [SerializeField] private bool hasSpawnedTestYourStrengthBoothTicket;
    // variable to access TestYourStrengthService.cs for height
    private TestYourStrengthService _testYourStrengthService;

    [Header("Dart Booth")]
    [SerializeField] private GameObject dartBoothTicketPrefab;
    [SerializeField] private Transform dartBoothTicketSpawnPoint;
    [SerializeField] private float dartBoothPrizeScore = 30f;
    [SerializeField] private bool hasSpawnedDartBoothTicket;
    // variable to access dartBoothService.cs for time
    private DartBoothService _dartBoothService;

    private void Awake()
    {
        // Check entire scene if there is another PrizeManager Instance
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
        // Ring Toss Booth
        // Service locator pattern
        _ringTossBoothService = FindObjectOfType<RingTossBoothService>();
        // subscribe to ScoreUpdated event; if score updates, run HandleRingTossScoreChange
        _ringTossBoothService.ScoreUpdated += HandleRingTossScoreChange;

        // Test Your Strength Booth
        // Service locator pattern
        _testYourStrengthService = FindObjectOfType<TestYourStrengthService>();
        // subscribe to event
        _testYourStrengthService.sliderHeightUpdated += HandleTestYourStrengthBoothSliderChange;

        // Dart Booth
        // Service locator pattern
        _dartBoothService = FindObjectOfType<DartBoothService>();
        // subscribe to event
        _dartBoothService.TimerUpdated += HandleDartBoothTimerChange;
    }


    private void OnDestroy()
    {
        // unsubcribe to events
        _ringTossBoothService.ScoreUpdated -= HandleRingTossScoreChange;
        _testYourStrengthService.sliderHeightUpdated += HandleTestYourStrengthBoothSliderChange;
        _dartBoothService.TimerUpdated -= HandleDartBoothTimerChange;
    }

    private void HandleRingTossScoreChange(int newScore)
    {
        // if ticket has not been instantiated and newscore is greater than or equal to prize score
        if (!hasSpawnedRingTossBoothTicket && newScore >= ringTossBoothPrizeScore)
        {
            // Instantiate ticket
            Instantiate(
                ringTossBoothTicketPrefab, 
                ringTossBoothTicketSpawnPoint.position, 
                ringTossBoothTicketSpawnPoint.rotation);
            // confirm ticket has been instantiated
            hasSpawnedRingTossBoothTicket = true;

            // spawn UI

            // spawn Achievement
        }
    }

    private void HandleTestYourStrengthBoothSliderChange(float newHeight)
    {
        // if ticket has not been instantiated and newscore is greater than or equal to prize score
        if (!hasSpawnedTestYourStrengthBoothTicket && newHeight >= TestYourStrengthBoothPrizeScore)
        {
            // Instantiate ticket
            Instantiate(
                testYourStrengthBoothTicketPrefab,
                testYourStrengthBoothTicketSpawnPoint.position,
                testYourStrengthBoothTicketSpawnPoint.rotation);
            // confirm ticket has been instantiated
            hasSpawnedTestYourStrengthBoothTicket = true;

            // spawn UI

            // spawn Achievement
        }
    }

    private void HandleDartBoothTimerChange(float newTime)
    {
        // if ticket has not been instantiated and newscore is greater than or equal to prize score
        if (!hasSpawnedDartBoothTicket && newTime <= dartBoothPrizeScore)
        {
            // Instantiate ticket
            Instantiate(
                dartBoothTicketPrefab,
                dartBoothTicketSpawnPoint.position,
                dartBoothTicketSpawnPoint.rotation);
            // confirm ticket has been instantiated
            hasSpawnedDartBoothTicket = true;

            // spawn UI

            // spawn Achievement
        }
    }

    
}
