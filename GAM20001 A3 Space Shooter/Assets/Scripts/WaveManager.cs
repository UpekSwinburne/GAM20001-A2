using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _spawners;
    [SerializeField] private float _timeBetweenWaves = 5f;

    private int _currentWave = 0;

    private void Start()
    {
        StartNewWave();
    }

    private void StartNewWave()
    {
        _currentWave++;

        foreach (var spawner in _spawners)
        {
            spawner.StartWave(_currentWave, _currentWave * 5); // For example, 5 enemies per wave
        }

        Debug.Log("Starting wave " + _currentWave);
        Invoke(nameof(StartNextWave), _timeBetweenWaves);
    }

    private void StartNextWave()
    {
        StartNewWave();
    }
}
