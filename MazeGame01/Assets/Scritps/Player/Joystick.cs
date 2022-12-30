using UnityEngine;

public static class Joystick
{

    private static UnityEngine.UI.Image _innerCircel;
    private static UnityEngine.UI.Image _outerCircel;

    private static UnityEngine.Vector2 _vec;

    private static UnityEngine.GameObject _joystick;

    private static float _joystickRadius;

    public static void OnInit(UnityEngine.UI.Image inner, UnityEngine.UI.Image outer, UnityEngine.GameObject joystick)
    {
        _innerCircel = inner;
        _outerCircel = outer;
        _joystick = joystick;

        _joystickRadius = _outerCircel.GetComponent<RectTransform>().sizeDelta.x / 4;
    }

    public static void OnActivate(UnityEngine.Vector2 _touchPosition)
    {
        _innerCircel.enabled = true;
        _outerCircel.enabled = true;

        _joystick.transform.position = _touchPosition;
    }

    public static void OnDeacitivate()
    {
        _innerCircel.enabled = false;
        _outerCircel.enabled = false;

        _joystick.transform.position = UnityEngine.Vector2.zero;
        _innerCircel.transform.position = UnityEngine.Vector2.zero;
        _vec = UnityEngine.Vector2.zero;
    }

    public static UnityEngine.Vector2 GetVector(UnityEngine.Touch touchPos)
    {
        ;
        UnityEngine.Vector2 dragPos = touchPos.position;
        _vec = (dragPos - (UnityEngine.Vector2)_outerCircel.transform.position).normalized;

        float joystickDist = UnityEngine.Vector2.Distance(dragPos, (UnityEngine.Vector2)_outerCircel.transform.position);

        if (joystickDist < _joystickRadius)
            _innerCircel.transform.position = (UnityEngine.Vector2)_outerCircel.transform.position + _vec * joystickDist;
        else
            _innerCircel.transform.position = (UnityEngine.Vector2)_outerCircel.transform.position + _vec * _joystickRadius;

        return _vec;
    }
}
