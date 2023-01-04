using UnityEngine;

public class CoinSwapper : BuffersWithTimer, IMapBuffer
{

    [SerializeField] private CoinSpawner coinSwapper;

    private void OnEnable()
    {
        MapBuffer.Listen(this);
    }

    private void OnDisable()
    {
        MapBuffer.Unlisten(this);
    }

    public void OnMapBuffed()
    {
        _buffIsActive = true;

        if (_simpleBuff == null)
            _simpleBuff = SwapCoins;
    }

    public void OnMapDebuffed()
    {
        _buffIsActive = false;
    }

    private void SwapCoins() => coinSwapper.ShuffleCoins();
}
