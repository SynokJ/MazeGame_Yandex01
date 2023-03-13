using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopViewer : MonoBehaviour
{

    [Header("Purchase Components:")]
    [SerializeField] private Image _purchaseImage;
    [SerializeField] private TMPro.TextMeshProUGUI _purchaseTitle;
    [SerializeField] private TMPro.TextMeshProUGUI _purchaseCost;

    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _activateButton;
    [SerializeField] private GameObject _deactivateButton;

    private List<ShopItemSO> items = new List<ShopItemSO>();
    private int _currentPurshaceId = 0;

    private readonly Color _DEFAULT_SELECTION_COLOR = Color.green;
    private readonly Color _DEFAULT_COLOR = Color.white;

    private void Start()
    {
        ResetPourchases();
        InitPurchases();
        OnPurshaseUpdate();
    }

    private void ResetPourchases()
    {
        if (items.IsUnityNull())
            return;

        for (int i = 0; i < items.Count; ++i)
            items[i].isBought = false;
    }

    private void InitPurchases()
    {
        PurchaseDatalist<PurchaseItem> res = UserData.instance.GetPurcahsesList();
        items = UserData.instance.GetShopItemSOs();

        for (int i = 0; i < items.Count; ++i)
            if (res.ContainsPurchaseItem(items[i].itemName))
                items[i].isBought = true;
    }

    public void OnPurshaseUpdate()
    {
        var currentItem = items[_currentPurshaceId];

        _purchaseImage.sprite = currentItem.itemSprite;
        _purchaseTitle.text = currentItem.itemName;
        _purchaseCost.text = currentItem.itemCost.ToString();

        _buyButton.SetActive(!currentItem.isBought);
        _activateButton.SetActive(currentItem.isBought);
        _deactivateButton.SetActive(currentItem.isBought);

        SetActivateColorStatus();
    }

    public void SwitchToNext()
    {
        if (_currentPurshaceId + 1 >= items.Count)
            _currentPurshaceId = 0;
        else
            _currentPurshaceId++;

        OnPurshaseUpdate();
    }

    public void SwitchToPrevious()
    {
        if (_currentPurshaceId - 1 < 0)
            _currentPurshaceId = items.Count - 1;
        else
            _currentPurshaceId--;

        OnPurshaseUpdate();
    }

    public void OnActivateButtonClicked()
    {
        items[_currentPurshaceId].isActivate = true;
        SetActivateColorStatus();
    }

    public void OnDeactivateButtonClicked()
    {
        items[_currentPurshaceId].isActivate = false;
        SetActivateColorStatus();
    }

    private void SetActivateColorStatus()
    {
        if (items[_currentPurshaceId].isActivate)
        {
            _activateButton.GetComponent<Image>().color = _DEFAULT_SELECTION_COLOR;
            _deactivateButton.GetComponent<Image>().color = _DEFAULT_COLOR;
        }
        else
        {
            _activateButton.GetComponent<Image>().color = _DEFAULT_COLOR;
            _deactivateButton.GetComponent<Image>().color = _DEFAULT_SELECTION_COLOR;
        }
    }

    public ShopItemSO GetCurrentShopItem() => items[_currentPurshaceId];
}