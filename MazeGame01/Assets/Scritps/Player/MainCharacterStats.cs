public static class MainCharacterStats
{
    private static int _lifePoitns = 1;
    private const int _MAP_ADDITIONAL_LIFE_POINTS = 3;
    private const int _MAP_ORIGIN_LIFE_POINTS = 1;

    public delegate void OnSpeedIsChanged();
    public static OnSpeedIsChanged speedChanged = default;

    public delegate void OnSpeedIsNormalized();
    public static OnSpeedIsNormalized speedIsNormalized = default;

    public delegate void OnHearthIsChanged(int param);
    public static OnHearthIsChanged hearthIsChanged = default;

    public delegate void OnHearthIsAdded();
    public static OnHearthIsAdded hearthIsAdded = default;

    public delegate void OnHearthIsCanceled();
    public static OnHearthIsCanceled hearthIsCanceled = default;


    public static void SetAdditionalLifePoints()
    {
        _lifePoitns = _MAP_ADDITIONAL_LIFE_POINTS;
        hearthIsAdded?.Invoke();
    }

    public static void SetOriginLifePoints()
    {
        _lifePoitns = _MAP_ORIGIN_LIFE_POINTS;
        hearthIsCanceled?.Invoke();
    }

    public static void SetBuffedSpeedValue() => speedChanged?.Invoke();

    public static void SetOriginalSpeedValue() => speedIsNormalized?.Invoke();

    public static bool CanPlayerDie()
    {
        if (_lifePoitns < 1)
            return true;

        hearthIsChanged?.Invoke(_lifePoitns - 1);
        _lifePoitns--;
        return false;
    }
}