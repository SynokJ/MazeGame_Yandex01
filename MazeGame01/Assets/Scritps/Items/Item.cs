using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class Item : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private Light2D _light;

    private Animator _anim;
    private TMPro.TextMeshProUGUI _text;

    private const string _PLAYER_TAG = "Player";
    private const string _ANIMATION_POPUP_NAME = "on_taken";
    private const string _BUFFER_PANEL_TAG_NAME = "Buffer Panel";
    private const string _BUFFER_TEXT_TAG_NAME = "Buffer Text";

    private const string _BUFFER_MEDICIN_TAG_NAME = "Medkit";
    private const string _BUFFER_LIGHTING_TAG_NAME = "Lighting";
    private const string _BUFFER_BOTTLE_TAG_NAME = "Bottle";
    private const string _BUFFER_MONEY_TAG_NAME = "Money";
    private const string _BUFFER_SHOES_TAG_NAME = "Shoes";

    private const string _BUFFER_MEDICIN_QUTE_EN = "Health Is Recieved";
    private const string _BUFFER_MEDICIN_QUTE_RU = "Здоровье Получено";

    private const string _BUFFER_LIGHTNING_QUTE_EN = "Lighting Is Improved";
    private const string _BUFFER_LIGHTNING_QUTE_RU = "Свет Улучшен";

    private const string _BUFFER_BOTTLE_QUTE_EN = "Water Is Drunk";
    private const string _BUFFER_BOTTLE_QUTE_RU = "Воды Выпита";

    private const string _BUFFER_MONEY_QUTE_EN = "Money Is Recieved";
    private const string _BUFFER_MONEY_QUTE_RU = "Деньги Приняты";

    private const string _BUFFER_SHOES_QUTE_EN = "Speed Is Up";
    private const string _BUFFER_SHOES_QUTE_RU = "Скорость Увеличена";

    protected int itemPoints = 0;

    protected abstract void OnBuffed();

    private void Start()
    {
        _anim = GameObject.FindGameObjectWithTag(_BUFFER_PANEL_TAG_NAME).GetComponent<Animator>();
        _text = GameObject.FindGameObjectWithTag(_BUFFER_TEXT_TAG_NAME).GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _PLAYER_TAG)
            OnTaken();
    }

    /// <summary>
    /// This method is so serious
    /// Don't even try to joke with him! XD
    /// </summary>
    private void OnTaken()
    {
        SetVisibleStatus(false);
        OnBuffed();

        _anim.Rebind();
        _anim.SetTrigger(_ANIMATION_POPUP_NAME);

        OnBufferTextShown();
        ItemCounter.AddCoin();
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

    private void OnBufferTextShown()
    {
        switch (gameObject.tag)
        {
            case _BUFFER_MEDICIN_TAG_NAME: _text.text = _BUFFER_MEDICIN_QUTE_EN; break;
            case _BUFFER_LIGHTING_TAG_NAME: _text.text = _BUFFER_LIGHTNING_QUTE_EN; break;
            case _BUFFER_BOTTLE_TAG_NAME: _text.text = _BUFFER_BOTTLE_QUTE_EN; break;
            case _BUFFER_MONEY_TAG_NAME: _text.text = _BUFFER_MONEY_QUTE_EN; break;
            case _BUFFER_SHOES_TAG_NAME: _text.text = _BUFFER_SHOES_QUTE_EN; break;
        }
    }
}
