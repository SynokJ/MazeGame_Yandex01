using System.Runtime.InteropServices;
using UnityEngine;

public class AuthButtonsController : MonoBehaviour
{
    [Header("Auth Components:")]
    [SerializeField] private GameObject _authButton;
    [SerializeField] private GameObject _resetButton;

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public static bool _isAuthCompleted = false;
    public static bool _isAuthSeccuded = true;

    private void Start()
    {
        if (!_isAuthSeccuded)
        {
            _authButton.SetActive(false);
            _resetButton.SetActive(false);
        }

        _authButton.SetActive(!_isAuthCompleted);
        _resetButton.SetActive(_isAuthCompleted);
    }

    public void OnAuthSuccess()
    {
        _authButton.SetActive(false);
        _resetButton.SetActive(true);

        _isAuthCompleted = true;
        _isAuthSeccuded = true;

        LoadExtern();
    }

    public void OnAuthNotSuccessed()
    {
        _authButton.SetActive(false);
        _isAuthSeccuded = false;
    }

    public void OnResetButtonClicked()
    {
        UserProgressManager.Instance.ResetPlayerInfo();
        _isAuthCompleted = true;
    }
}
