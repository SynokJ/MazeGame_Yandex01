using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour, IStateListener
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

    private bool _isTouchSupperted;

    private bool _isGameStarted = false;

    private void OnEnable()
    {
        GameStateListener.Listen(this);
    }

    private void OnDisable()
    {
        GameStateListener.CloseListener(this);
    }

    private void Start()
    {
        Joystick.OnInit(_innerCircleImg, _outerCircleImg, _joystick);
        Joystick.OnDeacitivate();

        _isTouchSupperted = Input.touchSupported;
    }

    private void Update()
    {
        if (!_isGameStarted)
            return;

        //if (_isTouchSupperted)
        //    OnMobileDevice();
        //else
        OnDesktopDevice();
    }

    private void OnDesktopDevice()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _originPos = Input.mousePosition;
            _isMoving = true;

            Joystick.OnActivate(_originPos);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Joystick.OnDeacitivate();
            _move.StopToMove();

            _isMoving = false;
        }


        if (_isMoving)
        {
            _move.MovePlayerByDirection(Joystick.GetVectorByPosition(Input.mousePosition));
            _anim.PlayAnimByDir(((Vector2)Input.mousePosition - _originPos).normalized);
        }
        else
            _anim.PlayAnimByDir(Vector2.zero);
    }

    private void OnMobileDevice()
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
        }

        if (_isMoving)
            _anim.PlayAnimByDir((_firstTouch.position - _originPos).normalized);
        else
            _anim.PlayAnimByDir(Vector2.zero);
    }

    public void OnGameStarted()
    {
        _isGameStarted = true;
        _move.SetPlayerOriginPosition();
    }

    public void OnGameFinished()
    {
        _isGameStarted = false;
        _move.StopToMove();
    }
}
