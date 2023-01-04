using System.Collections;
using UnityEngine;

public class DecelerationBuffer : BuffersWithTimer, IPlayerBuffer
{
    [SerializeField] private PlayerMove _move;
    private float _speedOrigin;

    private void OnEnable()
    {
        PlayerBuffer.Listen(this);
    }

    private void OnDisable()
    {
        PlayerBuffer.Unlisten(this);
    }

    public void OnPlayerBuffed()
    {
        _buffIsActive = true;

        if (_buffActionOn == null)
            _buffActionOn = DeceleratePlayerSpeed;
    }

    public void OnPlayerDebuffed()
    {
        _buffIsActive = false;
    }

    private IEnumerator DeceleratePlayerSpeed()
    {
        _speedOrigin = _move.SetSpeedValue(_move.GetSpeedValue() / 2);
        yield return new WaitForSeconds(_BUFFER_TIME * 0.5f);
        _move.ResetSpeedValue(_speedOrigin);
    }
}
