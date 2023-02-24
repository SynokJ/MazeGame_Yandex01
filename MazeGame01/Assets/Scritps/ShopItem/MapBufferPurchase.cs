using UnityEngine;

public class MapBufferPurchase : PurchaseItemActivator
{

    [Header("Buffers Components: ")]
    [SerializeField] private MapLightUp _mapLightUp;
    [SerializeField] private MapLightDown _mapLightDown;
    [SerializeField] private CoinSwapper _coinSwapper;

    protected override void OnActivate()
    {
        _mapLightUp.enabled = true;
        _mapLightDown.enabled = true;
        _coinSwapper.enabled = true;
    }

    protected override void OnDeactivate()
    {
        _mapLightUp.enabled = false;
        _mapLightDown.enabled = false;
        _coinSwapper.enabled = false;
    }
}
