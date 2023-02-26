using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{

    #region Singleton Cunstruction
    public static Yandex Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion

    [DllImport("__Internal")]
    private static extern void OnAuth();


    public void OnAuthButtonClicked()
    {
        OnAuth();
    }
}
