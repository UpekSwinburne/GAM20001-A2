using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveText;
    private WaveManager _waveManager; // Reference to the WaveManager script

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        _waveManager = FindObjectOfType<WaveManager>(); // Find the WaveManager script in the scene
    }

    // Update is called once per frame
    private void Update()
    {
        if (_waveManager != null)
        {
            _waveText.text = "Wave: " + _waveManager.CurrentWave;
        }
    }
}
