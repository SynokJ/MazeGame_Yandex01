using System.Collections;
using UnityEngine;

public abstract class BuffersWithTimer : MonoBehaviour
{
    private const float _MAP_LIGHT_TIME = 10.0f;
    private float _currentTime = 0.0f;

    protected const float _BUFFER_TIME = 3.0f;
    protected bool _buffIsActive = false;

    protected delegate IEnumerator OnBuffed();
    protected OnBuffed _buffActionOn = default;

    protected delegate void OnSimpleBuff();
    protected OnSimpleBuff _simpleBuff = default;

    private void Start()
    {
        _currentTime = _MAP_LIGHT_TIME;
    }

    private void Update()
    {
        if (!_buffIsActive)
            return;

        if (_currentTime <= 0)
        {
            _currentTime = _MAP_LIGHT_TIME;
            _simpleBuff?.Invoke();

            if (_buffActionOn != null)
                StartCoroutine(_buffActionOn?.Invoke());
        }

        _currentTime -= Time.deltaTime;
    }
}