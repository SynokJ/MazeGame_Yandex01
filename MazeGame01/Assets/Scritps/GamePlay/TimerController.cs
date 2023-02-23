using System;
using UnityEngine;

public class TimerController : MonoBehaviour, IStateListener
{
    [Header("Timer Components: ")]
    [SerializeField] private UnityEngine.UI.Slider _slider;

    private const float _TIMER_VALUE = 120.0f;
    private const float _ONE_STEP_POINT_VALUE = 5.17f;

    public static TimerController Instance = null;
    private float _currentTimerValue = 0.0f;
    private bool _isGameRunning = false;

    private void OnEnable()
    {
        GameStateListener.Listen(this);
    }

    private void OnDisable()
    {
        GameStateListener.CloseListener(this);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    void Update()
    {
        if (!_isGameRunning)
            return;

        if (_currentTimerValue < 0)
        {
            _currentTimerValue = _TIMER_VALUE;
            GameStateListener.FinishGame(GameStateListener.FinishType.lose);
        }
        else
        {
            _currentTimerValue -= Time.deltaTime;
            _slider.value = _currentTimerValue / _TIMER_VALUE;
        }
    }

    public void OnGameStarted()
    {
        _isGameRunning = true;
        _currentTimerValue = _TIMER_VALUE;
    }

    public void OnGameFinished()
    {
        _isGameRunning = false;
    }


    public float GetPoints()
    {
        float points = _currentTimerValue / _TIMER_VALUE * _ONE_STEP_POINT_VALUE;
        return points;
    }

    public void AddTime() => _currentTimerValue = _TIMER_VALUE;

}
