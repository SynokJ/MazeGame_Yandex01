public static class PlayerBuffer
{

    private static System.Collections.Generic.List<IPlayerBuffer> _playerBuffers = new System.Collections.Generic.List<IPlayerBuffer>();
    private static System.Random rnd = new System.Random();
    private static int _bufferId;

    public static void Listen(IPlayerBuffer buffer)
    {
        if (!_playerBuffers.Contains(buffer))
            _playerBuffers.Add(buffer);
    }

    public static void Unlisten(IPlayerBuffer buffer)
    {
        if (_playerBuffers.Contains(buffer))
            _playerBuffers.Remove(buffer);
    }

    public static void TriggerBuff()
    {
        if (_playerBuffers.Count == 0)
            return;

        _bufferId = rnd.Next(0, _playerBuffers.Count);
        _playerBuffers[_bufferId]?.OnPlayerBuffed();
    }

    public static void UndoBuff() => _playerBuffers[_bufferId]?.OnPlayerDebuffed();
}