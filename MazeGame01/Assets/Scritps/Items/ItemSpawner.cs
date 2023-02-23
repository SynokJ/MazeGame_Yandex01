using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, IStateListener
{
    [Header("Item Components:")]
    [SerializeField] private int _coinNum;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private List<GameObject> _coinPrefs = new List<GameObject>();

    [Header("Item Draw:")]
    [SerializeField] private TMPro.TextMeshProUGUI _itemText;

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

    private void Start()
    {
        this.enabled = true;

    }

    private void SpawnCoinsRandomly()
    {
        for (int i = 0; i < _coinNum; ++i)
        {
            GameObject currentCoin = Instantiate(_coinPrefs[Random.Range(0, _coinPrefs.Count)], _spawnPoints[i].position, Quaternion.identity);

            Item coin = currentCoin.GetComponent<Item>();
            coin.OnSpawned(_spawnPoints[Random.Range(0, _spawnPoints.Count)].position);

            _coins.Enqueue(currentCoin);
        }

        ItemCounter.SetOriginNum(_coinNum);
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
        if (_coins == null)
            return;

        foreach (var coin in _coins)
            Destroy(coin.gameObject);
    }

    public void OnItemTextChanged() => _itemText.text = (int.Parse(_itemText.text) - 1).ToString();

    public void OnGameStarted()
    {
        SpawnCoinsRandomly();

        _itemText.text = _coinNum.ToString();
        ItemCounter.InitAction(OnItemTextChanged);
    }

    public void OnGameFinished()
    {
        DestroyCoins();
    }
}
