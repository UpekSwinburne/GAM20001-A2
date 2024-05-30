using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    private EnemyCollectableDrop _collectableDrop;

    public event Action<GameObject> OnEnemyDestroyed;

    private void Awake()
    {
        _collectableDrop = GetComponent<EnemyCollectableDrop>();
    }

    public void DestroyEnemy(float delay)
    {
        StartCoroutine(DestroyAfterDelay(delay));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        // Drop collectable before destroying the enemy
        if (_collectableDrop != null)
        {
            _collectableDrop.RandomlyDropCollectable();
        }

        yield return new WaitForSeconds(delay);

        // Notify listeners before destroying the enemy
        OnEnemyDestroyed?.Invoke(gameObject);

        // Destroy the enemy game object after the specified delay
        Destroy(gameObject);
    }
}
