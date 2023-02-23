using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Components: ")]
    [SerializeField] private Rigidbody2D _rb;

    private float _moveSpeed = 5.0f;
    private const float _BUFFED_MOVEMENT_SPEED = 10.0f;
    private const float _NORMAL_MOVEMENT_SPEED = 5.0f;

    private const string _ENEMY_TAG_NAME = "Enemy";

    private void Start()
    {
        MainCharacterStats.speedChanged = SetBuffedSpeed;
        MainCharacterStats.speedIsNormalized = SetNomralSpeed;

        _moveSpeed = _NORMAL_MOVEMENT_SPEED;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(_ENEMY_TAG_NAME) && MainCharacterStats.CanPlayerDie())
        {
            GameStateListener.CloseBuffer();
            GameStateListener.FinishGame(GameStateListener.FinishType.lose);
        }
    }

    public void MovePlayerByDirection(Vector2 dir)
    {
        _rb.velocity = dir * _moveSpeed;
    }

    public void StopToMove()
    {
        _rb.velocity = Vector3.zero;
    }

    public float SetSpeedValue(float speed)
    {
        float originSpeed = _moveSpeed;
        _moveSpeed = speed;
        return originSpeed;
    }

    public void ResetSpeedValue(float speed) => _moveSpeed = speed;
    public float GetSpeedValue() => _moveSpeed;
    public void SetPlayerOriginPosition() => this.gameObject.transform.position = Vector2.zero;


    public void SetBuffedSpeed() => _moveSpeed = _BUFFED_MOVEMENT_SPEED;
    public void SetNomralSpeed() => _moveSpeed = _NORMAL_MOVEMENT_SPEED;
}