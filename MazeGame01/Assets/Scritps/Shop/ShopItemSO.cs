using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Scriptable Objects/Purchase", fileName = "Purchase")]
public class ShopItemSO : ScriptableObject
{

    public string itemName;
    public Sprite itemSprite;
    public int itemCost;
    public bool isBought;

    public PurchaseItemActivator purchaseItem;
}
