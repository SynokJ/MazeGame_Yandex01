public static class GameStateListener
{
    public enum FinishType { win = 0, lose = 1 }

    public static FinishType finishType { get; private set; }
    private static System.Collections.Generic.List<IStateListener> _stateListeners = new System.Collections.Generic.List<IStateListener>();
    private static System.Collections.Generic.List<IBufferCloser> _buffers = new System.Collections.Generic.List<IBufferCloser>();

    public static void Listen(IStateListener listener)
    {
        if (!_stateListeners.Contains(listener))
            _stateListeners.Add(listener);
    }

    public static void AddActivatedBuffer(IBufferCloser closer)
    {
        _buffers.Add(closer);
    }

    public static void CloseListener(IStateListener listener)
    {
        if (_stateListeners.Contains(listener))
            _stateListeners.Remove(listener);
    }

    public static void StartGame()
    {
        for (int i = 0; i < _stateListeners.Count; ++i)
            _stateListeners[i].OnGameStarted();

        UnityEngine.Time.timeScale = 1.0f;
    }

    public static void FinishGame(FinishType type = FinishType.win)
    {
        finishType = type;
        for (int i = 0; i < _stateListeners.Count; ++i)
            _stateListeners[i].OnGameFinished();

        UnityEngine.Time.timeScale = 0.0f;
    }

    public static void CloseBuffer()
    {
        for (int i = 0; i < _buffers.Count; ++i)
            _buffers[i].OnBufferClosed();
        _buffers.Clear();
    }
}
