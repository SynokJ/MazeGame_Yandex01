using UnityEngine;

public class AccelerationBuffer : MonoBehaviour, IPlayerBuffer
{
    [SerializeField] private PlayerMove _move;
    [SerializeField] private float _accelerationValue;

    private float _speedOrigin;

    private void OnEnable()
    {
        PlayerBuffer.Listen(this);
    }

    private void OnDisable()
    {
        PlayerBuffer.Unlisten(this);
    }

    public void OnPlayerBuffed() => _speedOrigin = _move.SetSpeedValue(_accelerationValue);
    public void OnPlayerDebuffed() => _move.ResetSpeedValue(_speedOrigin);
}
