using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Scriptable Objects/Purchase", fileName = "Purchase")]
public class ShopItemSO : ScriptableObject
{

    [Header("Shot Item Parameters:")]
    public string itemName;
    public int itemCost;
    public bool isBought;
    public bool isActivate;

    [Header("Shop Item Components:")]
    public Sprite itemSprite;
    public ShopViewer.ShopItemType type;
}
