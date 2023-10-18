using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private Text snapTurnButtonText;

    private PlayerBehavior _playerBehavior;

    private void Start()
    {
        _playerBehavior = FindObjectOfType<PlayerBehavior>();
    }

    public void OnStartClicked()
    {
        // change game state to Play game state
        GameManager.instance.UpdateGameState(GameState.Play);
        // turn off menu screens
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(false);
    }

    public void OnSettingsClicked()
    {
        // turn off main menu screen
        mainMenuScreen.SetActive(false);
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
        mainMenuScreen.SetActive(true);
        
    }
}
