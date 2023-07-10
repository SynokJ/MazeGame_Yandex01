using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player", fileName = "Player")]
public class PlayerSO : ScriptableObject
{
    [Header("Player Components:")]
    public GameObject playerGFX;
}
