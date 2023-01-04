using UnityEngine;

public class BuffGenerator : MonoBehaviour, IStateListener
{

    private void OnEnable()
    {
        GameStateListener.Listen(this);
    }

    private void OnDisable()
    {
        GameStateListener.CloseListener(this);
    }

    public void OnGameStarted()
    {
        PickRandomBuffers();
    }

    public void OnGameFinished()
    {
    }

    private void PickRandomBuffers()
    {
        MapBuffer.TriggerBuff();
        PlayerBuffer.TriggerBuff();
        EnemiesBuffer.TriggerBuff();
    }
}
