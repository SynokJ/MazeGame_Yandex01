using UnityEngine;

public static class Joystick
{

    private static UnityEngine.UI.Image _innerCircel;
    private static UnityEngine.UI.Image _outerCircel;

    private static UnityEngine.Vector2 _vec;

    private static UnityEngine.GameObject _joystick;

    public static void OnInit(UnityEngine.UI.Image inner, UnityEngine.UI.Image outer, UnityEngine.GameObject joystick)
    {
        _innerCircel = inner;
        _outerCircel = outer;
        _joystick = joystick;
    }

    public static void OnActivate(UnityEngine.Vector2 _touchPosition)
    {
        _innerCircel.enabled = true;
        _outerCircel.enabled = true;

        _joystick.transform.position = _touchPosition;

        UnityEngine.Debug.Log("OnActivate() => " + UnityEngine.Time.time);
    }

    public static void OnDeacitivate()
    {
        _innerCircel.enabled = false;
        _outerCircel.enabled = false;

        _joystick.transform.position = UnityEngine.Vector2.zero;
    }

    public static UnityEngine.Vector2 GetVector(UnityEngine.Vector2 _touchPosition)
    {

        UnityEngine.Debug.Log(_touchPosition);

        //float dist = UnityEngine.Vector2.Distance(_innerCircel.transform.position, _outerCircel.transform.position);
       
        //if (dist <= 1.0f)
        //    _innerCircel.transform.position = _touchPosition;


        return _vec;
    }
}
