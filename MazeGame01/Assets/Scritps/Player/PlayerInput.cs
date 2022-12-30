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

    private Touch _firstTouch;

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
                    Joystick.OnActivate(_firstTouch.position);
                    break;
                case TouchPhase.Moved:
                    _move.MovePlayerByDirection(Joystick.GetVector(_firstTouch));
                    break;
                case TouchPhase.Ended:
                    Joystick.OnDeacitivate();
                    _move.StopToMove();
                    break;
            }
        }
    }
}
