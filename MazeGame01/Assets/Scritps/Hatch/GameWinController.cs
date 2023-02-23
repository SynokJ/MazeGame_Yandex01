using UnityEngine;

public class GameWinController : MonoBehaviour
{

    private const string _PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(_PLAYER_TAG))
            TryWinGame();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals(_PLAYER_TAG))
            TryWinGame();
    }

    private void TryWinGame()
    {
        if (!ItemCounter.CanWin())
        {
            PlayerDialogueWindow.instance.MoreItemsNeeded();
            return;
        }

        GameStateListener.CloseBuffer();
        GameStateListener.FinishGame(GameStateListener.FinishType.win);
    }
}
