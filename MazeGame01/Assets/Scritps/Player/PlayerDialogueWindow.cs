using UnityEngine;

public class PlayerDialogueWindow : MonoBehaviour
{
    [Header("Dialogue Components: ")]
    [SerializeField] private TMPro.TextMeshProUGUI _dialogueText;
    [SerializeField] private GameObject _dialogueWindow;

    private const float _LETTER_SHOW_TIME = 0.1f;
    private const float _ADDITIONAL_TEXT_TIME = 5.0f;

    private const string _needToFindMore = "Find more items!";
    //private const string _takeMedicinbagItem = "Owh ";

    public static PlayerDialogueWindow instance = null;
    private bool _isSpeacking = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        _dialogueWindow.SetActive(false);
    }

    public void MoreItemsNeeded()
    {
        if (!_isSpeacking)
            StartCoroutine(OnSpeechIsUsed(_needToFindMore));
    }


    private System.Collections.IEnumerator OnSpeechIsUsed(string speech)
    {
        int letterIndex = 0;
        _dialogueWindow.SetActive(true);

        if (speech.Length == 0)
            yield return null;

        _isSpeacking = true;

        string res = speech[letterIndex].ToString();

        for (int i = 0; i < speech.Length; ++i)
        {
            if (letterIndex + 1 != speech.Length)
                letterIndex++;

            _dialogueText.text = res;
            yield return new WaitForSeconds(_LETTER_SHOW_TIME);
            res += speech[letterIndex];
        }

        yield return new WaitForSeconds(_ADDITIONAL_TEXT_TIME);

        _dialogueWindow.SetActive(false);
        _dialogueText.text = default;

        _isSpeacking = false;
    }
}
