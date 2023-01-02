public static class GameStateListener
{
    private static System.Collections.Generic.List<IStateListener> _stateListeners = new System.Collections.Generic.List<IStateListener>();

    public static void Listen(IStateListener listener)
    {
        if (!_stateListeners.Contains(listener))
            _stateListeners.Add(listener);
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
    }

    public static void FinishGame()
    {
        for (int i = 0; i < _stateListeners.Count; ++i)
            _stateListeners[i].OnGameFinished();
    }
}
