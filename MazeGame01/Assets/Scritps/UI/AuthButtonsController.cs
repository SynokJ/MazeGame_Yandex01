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

    private void Start()
    {
        _authButton.SetActive(!_isAuthCompleted);
        _resetButton.SetActive(_isAuthCompleted);
    }

    public void OnAuthSuccess()
    {
        _authButton.SetActive(false);
        _resetButton.SetActive(true);

        _isAuthCompleted = true;

        LoadExtern();
    }

    public void OnResetButtonClicked()
    {
        UserProgressManager.Instance.ResetPlayerInfo();
        _isAuthCompleted = true;
    }
}
