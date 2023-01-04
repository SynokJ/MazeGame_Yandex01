using UnityEngine;

public class InvertiveMovement : MonoBehaviour, IPlayerBuffer
{
    private void OnEnable()
    {
        PlayerBuffer.Listen(this);
    }

    private void OnDisable()
    {
        PlayerBuffer.Unlisten(this);
    }

    public void OnPlayerBuffed() => Joystick.InvertVec();
    public void OnPlayerDebuffed() => Joystick.ResetVec();
}
