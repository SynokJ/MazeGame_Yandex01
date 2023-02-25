using UnityEngine;

public class PlayerBufferActivator : PurchaseItemActivator
{

    [Header("Player Buffers Component: ")]
    [SerializeField] private AccelerationBuffer _acceleration;
    [SerializeField] private DecelerationBuffer _decceleration;
    [SerializeField] private InvertiveMovement _invertiveMovement;

    protected override void OnActivate()
    {
        _acceleration.enabled = true;
        _decceleration.enabled = true;
        _invertiveMovement.enabled = true;

        Debug.Log("Player Buffers Pack is Activated!");
    }

    protected override void OnDeactivate()
    {
        _acceleration.enabled = false;
        _decceleration.enabled = false;
        _invertiveMovement.enabled = false;

        Debug.Log("Player Buffers Pack is Deactivated!");
    }
}