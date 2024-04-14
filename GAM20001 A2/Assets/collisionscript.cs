using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionscript : MonoBehaviour
{
    public AudioClip collisionSound;
    public AudioSource audioSource;
    public GameObject objectPrefab;
    private bool hasAlreadyCollided = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy" && !hasAlreadyCollided)
        {   
            print("ENTER");
            
            if (audioSource != null && collisionSound != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(collisionSound);
            }


           
            Vector3 collisionPoint = other.ClosestPoint(transform.position);
            Instantiate(objectPrefab, collisionPoint, Quaternion.identity);
            hasAlreadyCollided = true;
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
   