public static class CoinCounter
{
    private static int _coinNum;
    private static int _coinNumOrigin;

    public static void AddCoin() => _coinNum++; 
    public static void SetOriginNum(int num) => _coinNumOrigin = num;
}