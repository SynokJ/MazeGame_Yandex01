public class LighterBuffer : Item, IBufferCloser
{

    private const string _PLAYER_TAG = "Player";
    private UnityEngine.Rendering.Universal.Light2D _lighter;

    private const float _ORIGINAL_FALLOFF_VALUE = 0.8f;
    private const float _BUFFED_FALLOFF_VALUE = 0.4f;

    private void OnEnable()
    {
        _lighter = UnityEngine.GameObject.FindGameObjectWithTag(_PLAYER_TAG)
            .GetComponentInChildren<UnityEngine.Rendering.Universal.Light2D>();
    }

    public void OnBufferClosed()
    {
        if (_lighter != null)
            _lighter.falloffIntensity = _ORIGINAL_FALLOFF_VALUE;
    }

    protected override void OnBuffed()
    {
        if (_lighter != null)
            _lighter.falloffIntensity = _BUFFED_FALLOFF_VALUE;

        GameStateListener.AddActivatedBuffer(this);
    }
}
