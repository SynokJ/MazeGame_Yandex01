public static class EnemiesBuffer
{

    private static System.Collections.Generic.List<IEnemyBuffer> _enemiesBuffers = new System.Collections.Generic.List<IEnemyBuffer>();
    private static System.Random rnd = new System.Random();
    private static int _bufferId = 0;

    public static void Listen(IEnemyBuffer buffer)
    {
        if (!_enemiesBuffers.Contains(buffer))
            _enemiesBuffers.Add(buffer);
    }

    public static void Unlisten(IEnemyBuffer buffer)
    {
        if (_enemiesBuffers.Contains(buffer))
            _enemiesBuffers.Remove(buffer);
    }

    public static void TriggerBuff()
    {
        if (_enemiesBuffers.Count == 0)
            return;

        _bufferId = rnd.Next(0, _enemiesBuffers.Count);
        _enemiesBuffers[_bufferId]?.OnEnemyBuffed();
    }

    public static void UndoBuff()
    {
        if (_enemiesBuffers == null || _enemiesBuffers.Count == 0)
            return;

        if (_bufferId >= 0 && _enemiesBuffers[_bufferId] != null)
            _enemiesBuffers[_bufferId].OnEnemyDebuffed();
    }
}