using UnityEngine;
using UnityEngine.UI;

public class InGameMenuBehavior : BaseMenuBehavior
{
    public void OnPauseGameClicked()
    {
        // change game state to Play game state
        GameManager.instance.UpdateGameState(GameState.Pause);
    }
}
