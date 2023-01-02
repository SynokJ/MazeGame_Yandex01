using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;

    public void OnPlayButtonClicked()
    {
        _mainMenuPanel.SetActive(false);
        GameStateListener.StartGame();
    }
}
