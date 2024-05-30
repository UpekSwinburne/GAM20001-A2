using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectableDrop : MonoBehaviour
{
    [SerializeField]
    private float _chanceOfCollectableDrop;

    private CollectableSpawner _collectableSpawner;

    private void Awake()
    {
        _collectableSpawner = FindObjectOfType<CollectableSpawner>();
    }

    public void RandomlyDropCollectable()
    {
        if (_collectableSpawner == null)
        {
            Debug.LogError("CollectableSpawner not found in the scene.");
            return;
        }

        float random = Random.Range(0f, 1f);

        if (_chanceOfCollectableDrop >= random)
        {
            _collectableSpawner.SpawnCollectable(transform.position);
        }
    }
}
