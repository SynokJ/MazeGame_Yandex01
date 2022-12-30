using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Components: ")]
    [SerializeField] private Rigidbody2D _rb;

    //[Header("Movement Parameters : ")]
    private const float _MOVEMENT_SPEED = 3.0f;

    public void MovePlayerByDirection(Vector2 dir)
    {
        _rb.velocity = dir * _MOVEMENT_SPEED;
    }

    public void StopToMove()
    {
        _rb.velocity = Vector3.zero;
    }
}
