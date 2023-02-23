using UnityEngine;

public class HearthPointsController : MonoBehaviour
{
    [SerializeField] private GameObject[] _hearths;

    void Start()
    {

        MainCharacterStats.hearthIsAdded = ShowHearths;
        MainCharacterStats.hearthIsChanged = HideHearthByIndex;
        MainCharacterStats.hearthIsCanceled = HideHearths;

        MainCharacterStats.hearthIsCanceled?.Invoke();
    }

    private void HideHearths()
    {
        for (int i = 0; i < _hearths.Length; ++i)
            _hearths[i].SetActive(false);
    }

    private void ShowHearths()
    {
        for (int i = 0; i < _hearths.Length; ++i)
            _hearths[i].SetActive(true);
    }

    private void HideHearthByIndex(int index)
    {
        if (index >= 0)
            _hearths[index].SetActive(false);
    }
}
