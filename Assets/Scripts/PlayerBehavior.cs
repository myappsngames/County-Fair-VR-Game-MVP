using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] XRRayInteractor[] _teleportationInteractors;

    private ActionBasedControllerManager[] _actionBasedControllerManagers;
    private DynamicMoveProvider _dynamicMoveProvider;
    private GrabMoveProvider[] _grabMoveProviders;

    private void Awake()
    {
        _actionBasedControllerManagers = GetComponentsInChildren<ActionBasedControllerManager>();
        _dynamicMoveProvider = GetComponentInChildren<DynamicMoveProvider>();
        _grabMoveProviders = GetComponentsInChildren<GrabMoveProvider>();
    }

    private void Start()
    {
        // Handle exception for starting before subscribe happens; updates to current Game State
        HandleGameStateChanged(GameManager.instance.State);
        // listen to GameManager event and subscribe to call HandleGameStateChanged
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }

    private void OnDestroy()
    {
        // unsubscribe
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }

    public bool ToggleSnapTurn()
    {
        // loop through all of the controller managers; ex. right and left hand
        foreach (var controllerManager in _actionBasedControllerManagers)
        {
            // set it to the opposite of what it already is
            controllerManager.smoothTurnEnabled = !controllerManager.smoothTurnEnabled;
        }
        // return whether snap turn is toggled on or off; return opposite
        return !_actionBasedControllerManagers[0].smoothTurnEnabled;
    }

    private void HandleGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                AllowPlayerMovement(false);
                break;
            case GameState.Play:
                AllowPlayerMovement(true);
                break;
            case GameState.Pause:
                AllowPlayerMovement(false);
                break;
            default:
                break;
        }
    }

    private void AllowPlayerMovement(bool canMove)
    {
        // set dynamicMoveProvider
        _dynamicMoveProvider.moveSpeed = canMove ? 1 : 0;

        // set grabMoveProvider
        foreach (var grabMoveProvider in _grabMoveProviders)
        {
            grabMoveProvider.enabled = canMove;
        }
        // set teleportation interactors
        foreach (var teleportationInteractor in _teleportationInteractors)
        {
            teleportationInteractor.enabled = canMove;
        }
    }
}
