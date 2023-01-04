using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Components: ")]
    [SerializeField] private Rigidbody2D _rb;

    private float _moveSpeed = 5.0f;

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
}