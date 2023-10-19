using UnityEngine;
using UnityEngine.UI;

// public abstract class; Can't create instances of it directly.
// instead create  new classes that inherit from abstract class
// new classes can be used to create game objects with specific properties and functionality.
public abstract class BaseMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject defaultMenuScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private Text snapTurnButtonText;

    private PlayerBehavior _playerBehavior;
    private bool _isMenuOpen; // starts false

    private void Start()
    {
        _playerBehavior = FindObjectOfType<PlayerBehavior>();
    }

    public void ToggleMenu()
    {
        // Does not show in-game UI if in Start Gamestate
        if (GameManager.instance.State == GameState.Start) return;

        _isMenuOpen = !_isMenuOpen;
        // set menu on or off
        defaultMenuScreen.SetActive(_isMenuOpen);
        // turn settings screen off
        settingsScreen.SetActive(false);
    }

    public void OnSettingsClicked()
    {
        // turn off main menu screen
        defaultMenuScreen.SetActive(false);
        // turn on settings screen
        settingsScreen.SetActive(true);
    }
    public void OnQuitClicked()
    {
        // change game state to Quit game state
        GameManager.instance.UpdateGameState(GameState.Quit);
    }

    public void OnToggleSnapTurnClicked()
    {
        // get data from playerBehavior.cs on whether snap turn is true or false
        bool isSnapTurnOn = _playerBehavior.ToggleSnapTurn();
        // update the button text
        if (isSnapTurnOn)
        {
            snapTurnButtonText.text = "Toggle Snap Turn: On";
        }
        else
        {
            snapTurnButtonText.text = "Toggle Snap Turn: Off";
        }
    }

    public void OnSettingsBackClicked()
    {
        // turn off settings screen
        settingsScreen.SetActive(false);
        // turn on main menu screen
        defaultMenuScreen.SetActive(true);
    }
}
