using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class UserData : MonoBehaviour
{
    #region Singleton
    public static UserData instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion

    private const string _FIRST_ITEM_NAME = "Map Modifier";
    private const string _SECOND_ITEM_NAME = "Player Modifier";
    private const string _THIRD_ITEM_NAME = "The One Of Us";

    private static int _coinAmount = 0;
    private PurchaseDatalist<PurchaseItem> _purchases = new PurchaseDatalist<PurchaseItem>();

    public int CoinAmount { get => _coinAmount; private set { } }
    private static string jsonRes = default;

    public void DecreaseCoins(int num)
    {
        _coinAmount -= num;

        if (_coinAmount < 0)
            _coinAmount = 0;
    }

    public void IncreaseCoins(int num)
    {
        _coinAmount += num;
        Debug.Log($"Coin Num Increased: {_coinAmount}");
    }

    public void AddPurchase(PurchaseItem data) => _purchases.AddItem(data);

    public void SavePurchases()
    {
        jsonRes = JsonUtility.ToJson(_purchases);

        PlayerInfo playerInfo = new PlayerInfo();

        playerInfo.coinAmount = _coinAmount;
        playerInfo.firstItem = _purchases.list[0].dataName.Equals(_FIRST_ITEM_NAME);

        if (_purchases.list.Count == 2)
            playerInfo.secondItem = _purchases.list[1].dataName.Equals(_SECOND_ITEM_NAME);

        if (_purchases.list.Count == 3)
            playerInfo.thirdItem = _purchases.list[2].dataName.Equals(_THIRD_ITEM_NAME);

        UserProgressManager.Instance.SetPlayerData(playerInfo);
    }

    public void SetCoinAmount(int coins) => _coinAmount = coins;

    public string GetBoughtList() => jsonRes;
    public bool TryGetPurchase(ShopItemSO item)
    {
        if (_purchases.list == null || _purchases.list.Count == 0)
            return false;

        if (item == null)
            return false;

        for (int i = 0; i < _purchases.list.Count; ++i)
            if (item.itemName.Equals(_purchases.list[i].dataName))
                return true;

        return false;
    }

}

[System.Serializable]
public class PurchaseItem
{
    public string dataName;
}

[System.Serializable]
public class PurchaseDatalist<T>
{
    public List<T> list = new List<T>();

    public void AddItem(T item)
    {
        if (!list.Contains(item))
            list.Add(item);
    }
}