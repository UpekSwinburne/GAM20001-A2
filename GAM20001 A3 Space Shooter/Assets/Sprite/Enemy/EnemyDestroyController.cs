using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    private EnemyCollectableDrop _collectableDrop;

    private void Awake()
    {
        _collectableDrop = GetComponent<EnemyCollectableDrop>();
    }

    public void DestroyEnemy(float delay)
    {
        // Drop collectable before destroying the enemy
        if (_collectableDrop != null)
        {
            _collectableDrop.RandomlyDropCollectable();
        }

        // Destroy the enemy game object after the specified delay
        Destroy(gameObject, delay);
    }
}
