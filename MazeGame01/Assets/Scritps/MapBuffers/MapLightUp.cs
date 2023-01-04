using System.Collections;
using UnityEngine;

public class MapLightUp : BuffersWithTimer, IMapBuffer
{

    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _light;

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
        _light.intensity = 1.0f;
        yield return new WaitForSeconds(_BUFFER_TIME);
        _light.intensity = 0.0f;
    }
}