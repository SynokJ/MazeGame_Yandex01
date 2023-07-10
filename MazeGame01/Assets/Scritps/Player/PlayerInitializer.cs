using UnityEngine;

public class PlayerInitializer : MonoBehaviour, IStateListener
{
    [Header("Player Skin Components:")]
    [SerializeField] private Transform _playerGFX_SpawnPoint;
    [SerializeField] private PlayerSO _playerDefGFX;
    [SerializeField] private PlayerAnimation _playerAnim;

    private GameObject _playerGFX = default;
    private PlayerSO _playerSO = default;
    private Vector2 _spawnPos = default;

    private void OnDestroy()
    {
        GameStateListener.CloseListener(this);
    }

    private void Start()
    {
        GameStateListener.Listen(this);
        _spawnPos = _playerGFX_SpawnPoint.position;
    }

    public void OnGameFinished()
    {
        Destroy(_playerGFX);
    }

    public void OnGameStarted()
    {

        _playerSO = SkinDataManager.GetCurrentPlayerSO();
        if (_playerSO == null)
            _playerSO = _playerDefGFX;
        else
            _playerDefGFX = _playerSO;

        _playerGFX = Instantiate(_playerSO.playerGFX, _spawnPos, Quaternion.identity);
        _playerGFX.transform.parent = _playerGFX_SpawnPoint;

        _playerAnim.InitAnim();
    }
}
