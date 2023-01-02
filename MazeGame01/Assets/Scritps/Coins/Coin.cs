using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Coin : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private Light2D _light;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            OnTaken();
    }

    private void OnTaken()
    {
        CoinCounter.AddCoin();
        SetVisibleStatus(false);
    }

    public void OnSpawned(Vector3 pos)
    {
        transform.position = pos;
        SetVisibleStatus(true);
    }

    private void SetVisibleStatus(bool status)
    {
        _spriteRenderer.enabled = status;
        _collider.enabled = status;
        _light.enabled = status;
    }
}
