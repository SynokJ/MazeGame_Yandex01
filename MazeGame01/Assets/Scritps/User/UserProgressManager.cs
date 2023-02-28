using System.Runtime.InteropServices;
using UnityEngine;


[System.Serializable]
public class PlayerInfo
{
    public int coinAmount;
    public bool firstItem;
    public bool secondItem;
    public bool thirdItem;

    public override string ToString()
    {
        return $"coins: {coinAmount}, first: {firstItem}, second: {secondItem}, third: {thirdItem}";
    }
}

public class UserProgressManager : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void LoadExtern();

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

    [Header("DEBUG TEXT:")]
    [SerializeField] private TMPro.TextMeshProUGUI _debugText;

    private PlayerInfo playerInfo;

    public void Save()
    {
        string json = JsonUtility.ToJson(playerInfo);
        SaveExtern(json);
    }

    public void SetPlayerInfo(string value)
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        _debugText.text = playerInfo.ToString();

        //UserData.instance.SetCoinAmount(playerInfo.coinAmount);
    }

    public void SetPlayerData(PlayerInfo info) => playerInfo = info;
}
