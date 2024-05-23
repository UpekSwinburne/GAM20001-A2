using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float lifeTime = 2f;
    // Update is called once per frame

    void Start()
    {
        Destroy(gameObject, lifeTime);
        
    }
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;

        transform.position = pos;

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
