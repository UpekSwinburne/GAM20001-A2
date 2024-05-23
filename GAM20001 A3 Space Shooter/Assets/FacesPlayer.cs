using UnityEngine;

public class FacesPlayer : MonoBehaviour
{
    public float rotationSpeed = 90f; 
    Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("Player Spaceship");

            if (go != null)
            {
                player = go.transform;
                Debug.Log("Player found: " + player.name);
            }
        }

        if (player == null)
        {
            Debug.Log("Player is null");
            return;
        }

        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

       
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
