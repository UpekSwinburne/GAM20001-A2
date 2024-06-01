using UnityEngine;

public class PowerUp : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float powerUpDuration = 5f; // Duration of the power-up effect

    public void OnCollected(GameObject player)
    {
        
        PlayerShoot playerShoot = player.GetComponent<PlayerShoot>();
        if (playerShoot != null)
        {
         
            playerShoot.ActivateTripleShot(powerUpDuration);
        }

        Destroy(gameObject);
    }
}
