using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [Header("Animation Components:")]
    [SerializeField] private GameObject _enemyGFX;
    [SerializeField] private Rigidbody2D _rb;

    private Animator _anim = default;
    private bool _isAnimInited = false;

    public void InitAnim()
    {
        _anim = _enemyGFX.GetComponentInChildren<Animator>();
        _isAnimInited = !(_anim == null);

        InvokeRepeating("PlayAnimationByRotation", 0, 1.0f);
    }


    private void PlayAnimationByRotation()
    {
        if (!_isAnimInited)
            return;

        if (_rb.velocity.x > 0)
        {
            _anim.SetBool("move_right", true);
            _anim.SetBool("move_left", false);

            _anim.SetTrigger("start_right");
        }
        else if (_rb.velocity.x < 0)
        {
            _anim.SetBool("move_right", false);
            _anim.SetBool("move_left", true);

            _anim.SetTrigger("start_left");
        }
    }
}
