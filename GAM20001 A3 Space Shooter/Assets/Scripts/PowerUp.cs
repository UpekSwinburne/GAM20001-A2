using UnityEngine;

public class PowerUp : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float powerUpDuration = 5f; // Duration of the power-up effect

    public void OnCollected(GameObject player)
    {
        // Check if the player object has a PlayerShoot component
        PlayerShoot playerShoot = player.GetComponent<PlayerShoot>();
        if (playerShoot != null)
        {
            // Activate the triple shot power-up for the player
            playerShoot.ActivateTripleShot(powerUpDuration);
        }

        // Destroy the power-up object after it's collected
        Destroy(gameObject);
    }
}
