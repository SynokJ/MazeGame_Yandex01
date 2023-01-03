using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour, IStateListener
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private int _coinNum;
    [SerializeField] private GameObject _coinPref;

    private Queue<GameObject> _coins = new Queue<GameObject>();

    private void OnEnable()
    {
        GameStateListener.Listen(this);
    }

    private void OnDisable()
    {
        GameStateListener.CloseListener(this);
    }

    private void SpawnCoinsRandomly()
    {
        for (int i = 0; i < _coinNum; ++i)
        {
            GameObject currentCoin = Instantiate(_coinPref, _spawnPoints[i].position, Quaternion.identity);

            Coin coin = currentCoin.GetComponent<Coin>();
            coin.OnSpawned(_spawnPoints[Random.Range(0, _spawnPoints.Count)].position);

            _coins.Enqueue(currentCoin);
        }
    }

    private void DestroyCoins()
    {
        if (_coins != null)
            return;

        foreach (var coin in _coins)
            Destroy(coin);
    }

    public void OnGameStarted()
    {
        SpawnCoinsRandomly();
    }

    public void OnGameFinished()
    {
        DestroyCoins();
    }
}