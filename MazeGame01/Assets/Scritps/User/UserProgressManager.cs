using System.Runtime.InteropServices;
using UnityEngine;


public class UserProgressManager : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    #region Singleton
    public static UserProgressManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    #endregion

    private PlayerInfo playerInfo;

    public void Save()
    {
        string json = JsonUtility.ToJson(playerInfo);
        SaveExtern(json);
    }

    public void SetPlayerInfo(string value)
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        UserData.instance.InitSavedPurchases(playerInfo);
    }

    public void ResetPlayerInfo()
    {
        playerInfo = new PlayerInfo();
        UserData.instance.InitSavedPurchases(playerInfo);
        Save();
    }

    public void SetPlayerData(PlayerInfo info)
    {
        playerInfo = info;
    }
}
