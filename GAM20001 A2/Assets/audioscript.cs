using UnityEngine;

public class audioscript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        // Set the AudioClip to loop
        source.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "A" key is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Play the AudioClip
            source.Play();
        }
    }
}
