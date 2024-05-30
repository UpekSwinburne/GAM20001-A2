using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _collectablePrefabs;

    public void SpawnCollectable(Vector2 position)
    {
        if (_collectablePrefabs.Count == 0)
        {
            Debug.LogWarning("No collectable prefabs assigned to the spawner.");
            return;
        }

        int index = Random.Range(0, _collectablePrefabs.Count);
        var selectedCollectable = _collectablePrefabs[index];

        Instantiate(selectedCollectable, position, Quaternion.identity);
    }
}
