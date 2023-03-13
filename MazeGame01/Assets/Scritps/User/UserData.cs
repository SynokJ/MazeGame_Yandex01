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

    [SerializeField] private List<ShopItemSO> _shopItemSOs = new List<ShopItemSO>();

    private static int _coinAmount = 0;
    private PurchaseDatalist<PurchaseItem> _purchases = new PurchaseDatalist<PurchaseItem>();

    public int CoinAmount { get => _coinAmount; private set { } }
    private static string jsonRes = default;

    public void InitSavedPurchases(PlayerInfo info)
    {
        _coinAmount = info.coinAmount;
        _purchases.ClearPurchases();

        _shopItemSOs[0].isBought = info.firstItem;
        _shopItemSOs[1].isBought = info.secondItem;
        _shopItemSOs[2].isBought = info.thirdItem;

        PurchaseItem tempItem = default;

        for (int i = 0; i < _shopItemSOs.Count; ++i)
            if (_shopItemSOs[i].isBought)
            {
                tempItem = new PurchaseItem();
                tempItem.dataName = _shopItemSOs[i].itemName;
                _purchases.AddItem(tempItem);
            }
    }

    public void DecreaseCoins(int num)
    {
        _coinAmount -= num;

        if (_coinAmount < 0)
            _coinAmount = 0;
    }

    public void SavePurchases()
    {
        jsonRes = JsonUtility.ToJson(_purchases);

        PlayerInfo playerInfo = new PlayerInfo();

        playerInfo.coinAmount = _coinAmount;

        playerInfo.firstItem = _purchases.ContainsPurchaseItem(_shopItemSOs[0].itemName);
        playerInfo.secondItem = _purchases.ContainsPurchaseItem(_shopItemSOs[1].itemName);
        playerInfo.thirdItem = _purchases.ContainsPurchaseItem(_shopItemSOs[2].itemName);

        UserProgressManager.Instance.SetPlayerData(playerInfo);
        UserProgressManager.Instance.Save();
    }

    public void IncreaseCoins(int num) => _coinAmount += num;
    public List<ShopItemSO> GetShopItemSOs() => _shopItemSOs;
    public void SetCoinAmount(int coins) => _coinAmount = coins;
    public void AddPurchase(PurchaseItem data) => _purchases.AddItem(data);
    public PurchaseDatalist<PurchaseItem> GetPurcahsesList() => _purchases;
    public void AddCoinsInRange(int max, int min) => _coinAmount += Random.Range(min, max);
    public bool TryGetPurchase(ShopItemSO item) => _purchases.ContainsPurchaseItem(item.name);
}