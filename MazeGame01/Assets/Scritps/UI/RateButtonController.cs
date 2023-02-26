using System.Runtime.InteropServices;
using UnityEngine;

public class RateButtonController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OnGameRated();

    [Header("Rate Components:")]
    [SerializeField] private GameObject _rateButton;

    private static bool _isGameRated = false;

    private void Start()
    {
        _rateButton.SetActive(!_isGameRated);
    }

    public void OnRateButtonClicked()
    {
        OnGameRated();
    }

    public void GameIsRated()
    {
        _isGameRated = true;
        _rateButton.SetActive(!_isGameRated);
    }
}
