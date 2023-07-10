using System.Collections.Generic;
using UnityEngine;

public class EnemyInitializer : MonoBehaviour, IStateListener
{
    [Header("Enemy Skin Components:")]
    [SerializeField] private EnemySO _enemyDefGFX;
    [SerializeField] private List<Transform> _enemyGFX_SpawnPoint = new List<Transform>();
    [SerializeField] private List<EnemyAnimation> _enemyAnim = new List<EnemyAnimation>();

    private List<GameObject> _enemyGFX = new List<GameObject>();
    private EnemySO _enemySO = default;

    private void Start()
    {
        GameStateListener.Listen(this);
    }

    private void OnDestroy()
    {
        GameStateListener.CloseListener(this);
    }

    public void OnGameFinished()
    {
        int size = _enemyGFX.Count;
        for (int i = 0; i < size; ++i)
            Destroy(_enemyGFX[i]);

        _enemyGFX.Clear();
    }

    public void OnGameStarted()
    {
        _enemySO = SkinDataManager.GetCurrentEnemySO();
        if (_enemySO == null)
            _enemySO = _enemyDefGFX;
        else
            _enemyDefGFX = _enemySO;

        GameObject _tempEnemyGFX = default;
        int size = _enemyGFX_SpawnPoint.Count;
        for (int i = 0; i < size; ++i)
        {
            _tempEnemyGFX = Instantiate(_enemySO.enemyGFX, _enemyGFX_SpawnPoint[i].position, Quaternion.identity);
            _tempEnemyGFX.transform.parent = _enemyGFX_SpawnPoint[i];
            _enemyAnim[i].InitAnim();

            _enemyGFX.Add(_tempEnemyGFX);
        }
    }
}
