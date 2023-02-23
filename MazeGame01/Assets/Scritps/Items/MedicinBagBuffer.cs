public class MedicinBagBuffer : Item, IBufferCloser
{

    protected override void OnBuffed()
    {
        GameStateListener.AddActivatedBuffer(this);
        MainCharacterStats.SetAdditionalLifePoints();
    }

    public void OnBufferClosed()
    {
        OnHearthDecreased();
    }

    protected void OnHearthDecreased() => MainCharacterStats.SetOriginLifePoints();
}
