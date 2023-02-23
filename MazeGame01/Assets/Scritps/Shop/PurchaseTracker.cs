using System;
using System.Collections.Generic;
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
        {
            OnBuyItem(currentItem);
            SavePurchaseData();
        }
        else
            Debug.Log("Purchase is failed!");

        UpdateMoneyText();
        _viewer.OnPurshaseUpdate();
    }

    private void OnBuyItem(ShopItemSO currentItem)
    {
        UserData.instance.DecreaseCoins(currentItem.itemCost);
        currentItem.isBought = true;

        UserData.instance.AddPurchase(new PurchaseData(currentItem));
        Debug.Log("Purchase is succeded!");
    }

    private void SavePurchaseData()
    {
        UserData.instance.SavePurchases();
    }

    private void UpdateMoneyText() => _currentMoney.text = UserData.instance.CoinAmount.ToString();
}
