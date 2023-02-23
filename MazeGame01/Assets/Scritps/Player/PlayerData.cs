using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private static int _coinsNum = 0;

    public static PlayerData instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        InitCoins();
    }

    public void AddCoinsInRange(int min, int max)
    {
        _coinsNum += Random.Range(min, max);
    }

    private void InitCoins()
    {
        /// Yandex feature
    }
}
