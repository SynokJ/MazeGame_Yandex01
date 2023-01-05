using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Rigidbody2D _rb;

    private void Update()
    {
        PlayAnimationByRotation();
    }

    private void PlayAnimationByRotation()
    {
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
