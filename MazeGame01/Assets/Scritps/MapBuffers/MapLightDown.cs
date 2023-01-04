using System.Collections;
using UnityEngine;

public class MapLightDown : BuffersWithTimer, IMapBuffer
{

    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _light;
    private float _initialIntesity;

    private void OnEnable()
    {
        MapBuffer.Listen(this);
    }

    private void OnDisable()
    {
        MapBuffer.Unlisten(this);
    }

    public void OnMapBuffed()
    {
        _buffIsActive = true;

        if (_buffActionOn == null)
        {
            _buffActionOn = TurnLightOff;
            _initialIntesity = _light.intensity;
        }
    }

    public void OnMapDebuffed()
    {
        _buffIsActive = false;
    }

    IEnumerator TurnLightOff()
    {
        _light.intensity = 0.0f;
        yield return new WaitForSeconds(_BUFFER_TIME);
        _light.intensity = _initialIntesity;
    }
}