public class SneakersBuffer : Item, IBufferCloser
{

    protected override void OnBuffed()
    {
        MainCharacterStats.SetBuffedSpeedValue();
        GameStateListener.AddActivatedBuffer(this);
    }
    public void OnBufferClosed() => MainCharacterStats.SetOriginalSpeedValue();
}
