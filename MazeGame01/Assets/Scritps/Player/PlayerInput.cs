using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [Header("Joystick Parameters:")]
    [SerializeField] private Image _innerCircleImg;
    [SerializeField] private Image _outerCircleImg;
    [SerializeField] private GameObject _joystick;

    [Header("Movement Parameters:")]
    [SerializeField] private PlayerMove _move;
    [SerializeField] private PlayerAnimation _anim;

    private Touch _firstTouch;
    private Vector2 _originPos = default;
    private bool _isMoving = false;

    private void Start()
    {
        Joystick.OnInit(_innerCircleImg, _outerCircleImg, _joystick);
        Joystick.OnDeacitivate();
    }

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            _firstTouch = Input.GetTouch(0);


            switch (_firstTouch.phase)
            {
                case TouchPhase.Began:
                    _originPos = _firstTouch.position;
                    _isMoving = true;
                    Joystick.OnActivate(_firstTouch.position);
                    break;
                case TouchPhase.Moved:
                    _move.MovePlayerByDirection(Joystick.GetVector(_firstTouch));
                    break;
                case TouchPhase.Ended:
                    Joystick.OnDeacitivate();
                    _move.StopToMove();

                    _isMoving = false;
                    break;
            }

            if (_isMoving)
                _anim.PlayAnimByDir((_firstTouch.position - _originPos).normalized);
            else
                _anim.PlayAnimByDir(Vector2.zero);
        }
    }
}
