using UnityEngine;

public class PurchaseInitializer : MonoBehaviour
{

    [Header("Purchaseable Components:")]
    [SerializeField] private PurchaseItemActivator[] _activators;

    private void Start()
    {
        for (int i = 0; i < _activators.GetLength(0); ++i)
        {
            ShopItemSO  tempShopItem = _activators[i].GetItemId();

            if (UserData.instance.TryGetPurchase(tempShopItem))
                _activators[i].OnActiveStatusController(tempShopItem.isActivate);
        }
    }
}
