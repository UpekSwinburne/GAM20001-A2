using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float fireDelay = 0.25f;
    float coolDownTimer = 0;
   // Update is called once per frame
    void Update()
    {
        coolDownTimer -= Time.deltaTime;
        if(Input.GetButton("Fire1") && coolDownTimer <= 0 )
        {
            Debug.Log("Fire!");
            coolDownTimer = fireDelay;
        }
    }
}
