using UnityEngine;

public abstract class PurchaseItemActivator : MonoBehaviour
{

    protected abstract void OnActivate();
    protected abstract void OnDeactivate();


    public void OnActiveStatusController(bool stat)
    {
        if (stat)
            OnActivate();
        else
            OnDeactivate();
    }
}
