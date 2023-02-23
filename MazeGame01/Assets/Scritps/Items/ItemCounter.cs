public static class ItemCounter
{
    private static int _currentItemNum;
    private static int _originItemNum;

    private static bool _areItemsCollected = false;

    public delegate void OnDrawItems();
    private static OnDrawItems drawItems = default;

    public static void AddCoin()
    {
        _currentItemNum++;
        _areItemsCollected = _currentItemNum >= _originItemNum;

        drawItems?.Invoke();
        UnityEngine.Debug.Log($"currectItenNum : {_currentItemNum}");
    }

    public static void SetOriginNum(int num)
    {
        _currentItemNum = 0;
        _originItemNum = num;
        _areItemsCollected = false;
    }

    public static bool CanWin() => _areItemsCollected;
    public static void InitAction(OnDrawItems other) => drawItems = other;
}