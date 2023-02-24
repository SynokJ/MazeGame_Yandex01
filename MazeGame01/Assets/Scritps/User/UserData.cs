using System.Collections.Generic;
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

    private static int _coinAmount = 2000;
    private PurchaseDatalist<PurchaseItem> _purchases = new PurchaseDatalist<PurchaseItem>();

    public int CoinAmount { get => _coinAmount; private set { } }
    private static string jsonRes = default;

    public void DecreaseCoins(int num)
    {
        _coinAmount -= num;

        if (_coinAmount < 0)
            _coinAmount = 0;
    }

    public void IncreaseCoins(int num) => _coinAmount += num;
    public void AddPurchase(PurchaseItem data) => _purchases.AddItem(data);

    public void SavePurchases()
    {
        jsonRes = JsonUtility.ToJson(_purchases);
    }

    public string GetBoughtList() => jsonRes;
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