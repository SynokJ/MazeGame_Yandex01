using UnityEngine;

public abstract class PurchaseItemActivator : MonoBehaviour
{

    [Header("Purcahse Components:")]
    [SerializeField] public ShopItemSO _identificator;

    protected abstract void OnActivate();
    protected abstract void OnDeactivate();

    public void OnActiveStatusController(bool stat)
    {
        if (stat)
            OnActivate();
        else
            OnDeactivate();
    }

    public ShopItemSO GetItemId()
    {
        if(_identificator == null)
            return default;

        return _identificator;
    }
}
