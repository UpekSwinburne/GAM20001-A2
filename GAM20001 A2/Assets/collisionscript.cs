using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionscript : MonoBehaviour
{
    public AudioClip collisionSound;
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print("ENTER");

            if (audioSource != null && collisionSound != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(collisionSound);
            }
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
   