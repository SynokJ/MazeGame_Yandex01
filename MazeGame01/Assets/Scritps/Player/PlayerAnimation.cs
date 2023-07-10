using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animation Components:")]
    [SerializeField] private GameObject _playerGFX;

    private Animator _anim = default;
    private bool _isAnimInited = false;

    public void InitAnim()
    {
        _anim = _playerGFX.GetComponentInChildren<Animator>();
        _isAnimInited = !(_anim == null);
    }

    public void PlayAnimByDir(Vector2 dir)
    {
        if (!_isAnimInited)
            return;

        if (dir.x > 0.01f && !_anim.GetBool("move_right"))
        {
            _anim.SetBool("move_left", false);
            _anim.SetBool("move_right", true);
        }
        else if (dir.x < -0.01f && !_anim.GetBool("move_left"))
        {
            _anim.SetBool("move_left", true);
            _anim.SetBool("move_right", false);
        }
        else if (dir.x == 0.0f && dir.y == 0.0f)
        {
            _anim.SetBool("move_right", false);
            _anim.SetBool("move_left", false);
        }
    }
}
