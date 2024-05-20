using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 12f;
    public float rotSpeed = 180f;
    public float shipBoundaryRadius = 0.5f;
    public float boundaryMargin = 2.0f; // Margin to increase the boundaries

    void Update()
    {
        // Rotate the ship
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        // Move the ship
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

        // Calculate camera boundaries with margin
        float camHeight = Camera.main.orthographicSize + boundaryMargin;
        float camWidth = (Camera.main.orthographicSize * Camera.main.aspect) + boundaryMargin;

        // Restrict the player to the boundaries (Vertical Boundaries)
        if (pos.y + shipBoundaryRadius > camHeight)
        {
            pos.y = camHeight - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -camHeight)
        {
            pos.y = -camHeight + shipBoundaryRadius;
        }

        // Restrict the player to the boundaries (Horizontal Boundaries)
        if (pos.x + shipBoundaryRadius > camWidth)
        {
            pos.x = camWidth - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < -camWidth)
        {
            pos.x = -camWidth + shipBoundaryRadius;
        }

        transform.position = pos;
    }
}