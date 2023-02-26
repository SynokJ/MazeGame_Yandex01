using UnityEngine;

public class WinGameController : MonoBehaviour, IStateListener
{
    [Header("Win Components: ")]
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private TMPro.TextMeshProUGUI _payerScoreText;

    private const string _SCORE_TITLE = "The score is : ";

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
        if (_winPanel.activeSelf)
            _winPanel.SetActive(false);
    }

    public void OnGameFinished()
    {
        if (GameStateListener.finishType != GameStateListener.FinishType.win)
            return;

        if (!_winPanel.activeSelf)
        {
            _payerScoreText.text = _SCORE_TITLE + TimerController.Instance.GetPoints().ToString("F2");
            _winPanel.SetActive(true);
        }
    }

    public void OnMenuButtonClicked()
    {
        _winPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }
}
