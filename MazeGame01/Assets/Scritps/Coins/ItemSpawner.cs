using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, IStateListener
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private int _coinNum;
    [SerializeField] private List<GameObject> _coinPrefs = new List<GameObject>();

    private Queue<GameObject> _coins = new Queue<GameObject>();
    private Queue<Vector3> _busyPosition = new Queue<Vector3>();

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
            GameObject currentCoin = Instantiate(_coinPrefs[Random.Range(0, _coinPrefs.Count)], _spawnPoints[i].position, Quaternion.identity);

            Items coin = currentCoin.GetComponent<Items>();
            coin.OnSpawned(_spawnPoints[Random.Range(0, _spawnPoints.Count)].position);

            _coins.Enqueue(currentCoin);
        }
    }

    public void ShuffleCoins()
    {
        _busyPosition.Clear();

        foreach (var coin in _coins)
        {
            int posId = Random.Range(0, _spawnPoints.Count);

            while (_busyPosition.Contains(_spawnPoints[posId].position))
                posId = Random.Range(0, _spawnPoints.Count);

            coin.transform.position = _spawnPoints[posId].position;
            _busyPosition.Enqueue(coin.transform.position);
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
