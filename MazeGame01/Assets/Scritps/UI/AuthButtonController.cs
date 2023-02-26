using UnityEngine;

public class AuthButtonController : MonoBehaviour
{
    [Header("Auth Components:")]
    [SerializeField] private GameObject _authButton;

    public static bool _isAuthCompleted = false;

    private void Start()
    {
        _authButton.SetActive(!_isAuthCompleted);
    }

    public void OnAuthSuccess()
    {
        Debug.Log("On Auth button hide");
        _authButton.SetActive(false);
        _isAuthCompleted = true;
    }
}
