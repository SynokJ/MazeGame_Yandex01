using UnityEngine;

public class HatchRandomSpawner : MonoBehaviour, IStateListener
{
    [Header("Spawn Components:")]
    [SerializeField] private Transform[] _spawnPointsTr;
    [SerializeField] private Transform _hitchTr;

    private void OnDisable()
    {
        GameStateListener.CloseListener(this);
    }

    private void Start()
    {
        GameStateListener.Listen(this);
    }

    public void OnGameFinished()
    {
        // nothing
    }

    public void OnGameStarted()
    {
        if (_spawnPointsTr.Length <= 0)
            return;

        _hitchTr.position = _spawnPointsTr[Random.Range(0, _spawnPointsTr.Length)].position;
    }
}
