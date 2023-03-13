using System;
using UnityEngine;

public class PurchaseTracker : MonoBehaviour
{

    [Header("Purchase Components:")]
    [SerializeField] private ShopViewer _viewer;
    [SerializeField] private TMPro.TextMeshProUGUI _currentMoney;

    private void Start()
    {
        UpdateMoneyText();
    }

    public void TryBuyItem()
    {
        var currentItem = _viewer.GetCurrentShopItem();

        if (UserData.instance.CoinAmount >= currentItem.itemCost)
            OnBuyItem(currentItem);

        UpdateMoneyText();
        _viewer.OnPurshaseUpdate();
    }

    private void OnBuyItem(ShopItemSO currentItem)
    {
        UserData.instance.DecreaseCoins(currentItem.itemCost);
        currentItem.isBought = true;

        PurchaseItem data = new PurchaseItem();
        data.dataName = currentItem.itemName;

        UserData.instance.AddPurchase(data);
        UserData.instance.SavePurchases();

        UserProgressManager.Instance.Save();
    }

    private void UpdateMoneyText() => _currentMoney.text = UserData.instance.CoinAmount.ToString();
}
