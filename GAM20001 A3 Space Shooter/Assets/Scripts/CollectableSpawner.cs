using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _collectablePrefabs;

    [SerializeField]
    private int _maxCollectablesOnScreen = 5; // Maximum number of collectables allowed on screen

    private List<GameObject> _activeCollectables = new List<GameObject>();

    public void SpawnCollectable(Vector2 position)
    {
        if (_activeCollectables.Count < _maxCollectablesOnScreen)
        {
            int index = Random.Range(0, _collectablePrefabs.Count);
            var selectedCollectable = _collectablePrefabs[index];

            GameObject collectable = Instantiate(selectedCollectable, position, Quaternion.identity);
            _activeCollectables.Add(collectable);
        }
        else if (_activeCollectables.Count == _maxCollectablesOnScreen)
        {
            // Check if any collectable has been collected or destroyed
            for (int i = 0; i < _activeCollectables.Count; i++)
            {
                if (_activeCollectables[i] == null)
                {
                    // If a collectable is destroyed, remove it from the active list
                    _activeCollectables.RemoveAt(i);
                    break;
                }
            }

            // If there are fewer than 5 collectables on screen after removal, spawn a new one
            if (_activeCollectables.Count < _maxCollectablesOnScreen)
            {
                int index = Random.Range(0, _collectablePrefabs.Count);
                var selectedCollectable = _collectablePrefabs[index];

                GameObject collectable = Instantiate(selectedCollectable, position, Quaternion.identity);
                _activeCollectables.Add(collectable);
            }
        }
    }

    // Call this method when a collectable is collected or destroyed to remove it from the active list
    public void RemoveCollectable(GameObject collectable)
    {
        if (_activeCollectables.Contains(collectable))
        {
            _activeCollectables.Remove(collectable);
        }
    }
}
