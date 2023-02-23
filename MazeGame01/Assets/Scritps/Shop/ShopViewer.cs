using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopViewer : MonoBehaviour
{

    [Header("Purchase Components:")]
    [SerializeField] private Image _purchaseImage;
    [SerializeField] private TMPro.TextMeshProUGUI _purchaseTitle;
    [SerializeField] private TMPro.TextMeshProUGUI _purchaseCost;

    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _selectButton;

    [Header("Shop Items:")]
    [SerializeField] private List<ShopItemSO> _shopItems = new List<ShopItemSO>();
    private int _currentPurshaceId = 0;

    private void Start()
    {
        ResetPurchases();

        var res = JsonUtility.FromJson<PurchaseDatalist<PurchaseData>>(UserData.instance.GetBoughtList());

        if (res != null)
            for (int i = 0; i < res.GetLen(); ++i)
                if (res.GetValue(i).name == _shopItems[i].itemName)
                    _shopItems[i].isBought = true;

        OnPurshaseUpdate();
    }

    private void ResetPurchases()
    {
        for (int i = 0; i < _shopItems.Count; ++i)
            _shopItems[i].isBought = false;
    }

    public void OnPurshaseUpdate()
    {
        var currentItem = _shopItems[_currentPurshaceId];

        _purchaseImage.sprite = currentItem.itemSprite;
        _purchaseTitle.text = currentItem.itemName;
        _purchaseCost.text = currentItem.itemCost.ToString();

        _buyButton.SetActive(!currentItem.isBought);
        _selectButton.SetActive(currentItem.isBought);
    }

    public void SwitchToNext()
    {
        if (_currentPurshaceId + 1 >= _shopItems.Count)
            _currentPurshaceId = 0;
        else
            _currentPurshaceId++;

        OnPurshaseUpdate();
    }

    public void SwitchToPrevious()
    {
        if (_currentPurshaceId - 1 < 0)
            _currentPurshaceId = _shopItems.Count - 1;
        else
            _currentPurshaceId--;

        OnPurshaseUpdate();
    }

    public ShopItemSO GetCurrentShopItem() => _shopItems[_currentPurshaceId];
}