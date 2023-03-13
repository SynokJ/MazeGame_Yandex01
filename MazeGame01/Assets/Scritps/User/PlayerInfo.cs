[System.Serializable]
public class PlayerInfo
{
    public int coinAmount;
    public bool firstItem;
    public bool secondItem;
    public bool thirdItem;

    public PlayerInfo()
    {
        coinAmount = 0;
        firstItem = false;
        secondItem = false;
        thirdItem = false;
    }

    public override string ToString() => $"coins: {coinAmount}, first: {firstItem}, second: {secondItem}, third: {thirdItem}";
}
