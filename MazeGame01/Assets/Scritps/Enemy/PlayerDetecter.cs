using UnityEngine;

public class PlayerDetecter : MonoBehaviour, IStateListener
{

    [SerializeField] private EnemyAI _enemyAi;

    private const string _PLAYER_TAG_NAME = "Player";
    private bool _isPlayerDetected = false;

    private void OnDisable()
    {
        GameStateListener.CloseListener(this);
    }

    private void Start()
    {
        GameStateListener.Listen(this);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isPlayerDetected)
            return;

        if (collision.tag.Equals(_PLAYER_TAG_NAME))
        {
            _enemyAi.OnPlayerDetected(collision.transform);
            _isPlayerDetected = true;
        }
    }

    public void OnGameStarted() => _isPlayerDetected = false;
    public void OnGameFinished() => _isPlayerDetected = true;
}
