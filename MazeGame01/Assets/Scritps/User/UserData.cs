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
    private PurchaseDatalist<PurchaseData> _purchases = new PurchaseDatalist<PurchaseData>();

    public int CoinAmount { get => _coinAmount; private set { } }
    private string jsonRes;

    public void DecreaseCoins(int num)
    {
        Debug.Log($"Before: {_coinAmount}, After: {_coinAmount - num}, Time: {Time.time}");

        _coinAmount -= num;

        if (_coinAmount < 0)
            _coinAmount = 0;
    }

    public void IncreaseCoins(int num) => _coinAmount += num;

    public void AddPurchase(PurchaseData data)
    {
        if (!_purchases.Contains(data))
            _purchases.Add(data);
    }

    public void SavePurchases()
    {
        jsonRes = JsonUtility.ToJson(_purchases);
        Debug.Log(jsonRes);
    }

    public string GetBoughtList() => jsonRes;
}

[System.Serializable]
public class PurchaseDatalist<T>
{
    public List<T> list = new List<T>();

    public bool Contains(T t) => list.Contains(t);
    public void Add(T t) => list.Add(t);
    public int GetLen() => list.Count;
    public T GetValue(int index) => list[index];
}

[System.Serializable]
public class PurchaseData
{
    public string name;

    public PurchaseData(ShopItemSO item)
    {
        name = item.itemName;
    }
}