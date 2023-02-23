public class CoinBagBuffer : Item
{
    private const int _MIN_COIN_NUM = 5;
    private const int _MAX_COIN_NUM = 15;

    protected override void OnBuffed() => PlayerData.instance.AddCoinsInRange(_MIN_COIN_NUM, _MAX_COIN_NUM);
}
