using UnityEngine;

public class LoseGameController : MonoBehaviour, IStateListener
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _mainMenuPanel;

    private void OnEnable()
    {
        GameStateListener.Listen(this);
    }

    private void OnDisable()
    {
        GameStateListener.CloseListener(this);
    }
    public void OnGameStarted()
    {
        if (_losePanel.activeSelf)
            _losePanel.SetActive(false);
    }

    public void OnGameFinished()
    {
        if (GameStateListener.finishType != GameStateListener.FinishType.lose)
            return;

        if (!_losePanel.activeSelf)
            _losePanel.SetActive(true);
    }

    public void OnMenuButtonClicked()
    {
        _losePanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }
}
