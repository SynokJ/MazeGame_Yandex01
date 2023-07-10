public static class SkinDataManager
{
    private static PlayerSO _currentPlayerSO = default;
    private static EnemySO _currentEnemySO = default;

    public static void SetPlayerSO(PlayerSO playerSO)
        => _currentPlayerSO = playerSO;

    public static void SetEnemySO(EnemySO enemySO)
        => _currentEnemySO = enemySO;


    public static PlayerSO GetCurrentPlayerSO()
        => _currentPlayerSO;

    public static EnemySO GetCurrentEnemySO()
        => _currentEnemySO;
}
