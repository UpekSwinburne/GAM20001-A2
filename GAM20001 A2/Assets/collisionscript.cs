using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionscript : MonoBehaviour
{
    public AudioClip collisionSound;
    public AudioSource audioSource;
    public GameObject objectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("ENTER");

            if (audioSource != null && collisionSound != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(collisionSound);
            }

            Vector3 collisionPoint = other.ClosestPoint(transform.position);

            // Instantiate the objectPrefab at the collision point
            Instantiate(objectPrefab, collisionPoint, Quaternion.identity);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("STAY");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("EXIT");

        }
    }
}
    // Start is called before the first frame update
   