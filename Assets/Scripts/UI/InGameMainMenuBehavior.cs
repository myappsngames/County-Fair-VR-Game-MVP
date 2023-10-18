using UnityEngine;
using UnityEngine.UI;

public class InGameMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject inGameMenuScreen;
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
        _isMenuOpen = !_isMenuOpen;
        // set menu on or off
        inGameMenuScreen.SetActive(_isMenuOpen);
        // turn settings screen off
        settingsScreen.SetActive(false);
    }

    public void OnSettingsClicked()
    {
        // turn off main menu screen
        inGameMenuScreen.SetActive(false);
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

    public void OnSettingsBackClick()
    {
        // turn off settings screen
        settingsScreen.SetActive(false);
        // turn on main menu screen
        inGameMenuScreen.SetActive(true);
        
    }
}
