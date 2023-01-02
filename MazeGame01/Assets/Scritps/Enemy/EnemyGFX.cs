using UnityEngine;

public class EnemyGFX : MonoBehaviour
{

    [SerializeField] private Pathfinding.AIPath _aiPath;

    void Update()
    {
        if (_aiPath.desiredVelocity.x >= 0.01f)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (_aiPath.desiredVelocity.x <= -0.01f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    }
}

