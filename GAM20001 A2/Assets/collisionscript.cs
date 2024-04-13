using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionscript : MonoBehaviour
{

    public GameObject createdObjectPrefab;
    public AudioClip collisionSound;
    public AudioSource audioSource;

    private bool isColliding = false; // Flag to track if the trigger is colliding

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            // Instantiate the created object at the collision location
            Instantiate(createdObjectPrefab, transform.position, Quaternion.identity);

            // Play the collision sound effect if it's not already playing
            if (!audioSource.isPlaying && collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }

            isColliding = true; // Set the flag to true to indicate collision
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
        if (other.gameObject.CompareTag("enemy"))
        {
            // Stop the sound effect if the trigger is no longer colliding
            audioSource.Stop();
            isColliding = false; // Set the flag to false to indicate no collision
        }
    }
}
    // Start is called before the first frame update
   