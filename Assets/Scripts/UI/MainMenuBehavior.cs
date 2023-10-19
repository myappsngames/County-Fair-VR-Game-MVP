using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehavior : BaseMenuBehavior
{
    public void OnStartClicked()
    {
        // change game state to Play game state
        GameManager.instance.UpdateGameState(GameState.Play);
        // call ToggleMenu() from abstract class
        base.ToggleMenu();
    }
}
