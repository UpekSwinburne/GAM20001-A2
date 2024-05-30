using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _initialSpawnDelay = 1f;
    [SerializeField] private float _spawnDelayBetweenEnemies = 0.5f;

    private WaveManager _waveManager;
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _waveManager = FindObjectOfType<WaveManager>();
    }

    public void StartWave(int waveNumber, int totalEnemies)
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemiesCoroutine(totalEnemies));
    }

    private IEnumerator SpawnEnemiesCoroutine(int totalEnemies)
    {
        yield return new WaitForSeconds(_initialSpawnDelay);

        for (int i = 0; i < totalEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnDelayBetweenEnemies);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
    }

    public void StopSpawning()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
}
