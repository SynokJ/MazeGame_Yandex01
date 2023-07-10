using System.Collections.Generic;

[System.Serializable]
public class PurchaseDatalist<T>
{
    public List<T> list = null;

    public PurchaseDatalist()
    {
        list = new List<T>();
    }

    ~PurchaseDatalist()
    {
        list.Clear();
    }

    public void AddItem(T item)
    {
        PurchaseItem tempItem = item as PurchaseItem;

        if (tempItem != null && !ContainsPurchaseItem(tempItem.dataName))
            list.Add(item);
    }

    public bool ContainsPurchaseItem(string name)
    {
        PurchaseItem purchaseItem = default;

        if (list == null || list.Count == 0)
            return false;

        for (int i = 0; i < list.Count; ++i)
        {
            purchaseItem = list[i] as PurchaseItem;
            if (purchaseItem != null && purchaseItem.dataName.Equals(name))
                return true;
        }

        return false;
    }

    public void ClearPurchases() 
        => list.Clear();
}
