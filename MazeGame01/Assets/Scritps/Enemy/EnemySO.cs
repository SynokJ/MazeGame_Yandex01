using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy", fileName = "Enemy")]
public class EnemySO : ScriptableObject
{
    [Header("Enemy Components:")]
    public GameObject enemyGFX;
}
