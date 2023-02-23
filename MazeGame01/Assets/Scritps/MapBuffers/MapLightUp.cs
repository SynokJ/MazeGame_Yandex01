using System.Collections;
using UnityEngine;

public class MapLightUp : BuffersWithTimer, IMapBuffer
{

    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _light;

    private const float _MAX_GLOBAL_LIGHT_INTENSITY = 0.25f;
    private const float _MIN_GLOBAL_LIGHT_INTENSITY = 0.0f;

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
            _buffActionOn = TurnLightOn;
    }

    public void OnMapDebuffed()
    {
        _buffIsActive = false;
    }

    IEnumerator TurnLightOn()
    {
        _light.intensity = _MAX_GLOBAL_LIGHT_INTENSITY;
        yield return new WaitForSeconds(_BUFFER_TIME);
        _light.intensity = _MIN_GLOBAL_LIGHT_INTENSITY;
    }
}