public static class MapBuffer
{

    private static System.Collections.Generic.List<IMapBuffer> _mapBuffers = new System.Collections.Generic.List<IMapBuffer>();
    private static System.Random rnd = new System.Random();
    private static int _bufferId;

    public static void Listen(IMapBuffer buffer)
    {
        if (!_mapBuffers.Contains(buffer))
            _mapBuffers.Add(buffer);
    }

    public static void Unlisten(IMapBuffer buffer)
    {
        if (_mapBuffers.Contains(buffer))
            _mapBuffers.Remove(buffer);
    }

    public static void TriggerBuff()
    {
        if (_mapBuffers.Count == 0)
            return;

        _bufferId = rnd.Next(0, _mapBuffers.Count);
        _mapBuffers[_bufferId]?.OnMapBuffed();
    }

    public static void UndoBuff() => _mapBuffers[_bufferId]?.OnMapDebuffed();
}