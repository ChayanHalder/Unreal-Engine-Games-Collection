﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade2_MultiShot : MonoBehaviour
{
    public ParticleSystem ShockWaveSmall;

    Rocket_start Rs;
    public float Multishot_time;

    private GameObject Rocket;




    private void Start()
    {
        Rocket = GameObject.FindWithTag("Rocket");

    }

    private void Update()
    {
        gameObject.transform.position += Vector3.down * Time.deltaTime;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
            Instantiate(ShockWaveSmall, gameObject.transform.position, Quaternion.identity);


            Rs = collision.GetComponent<Rocket_start>();
            Rs.enable_multishot_upgrade(Multishot_time);

            Destroy(this.gameObject);
        }


        if (collision.gameObject.tag == "Rocket_Side")
        {
            Instantiate(ShockWaveSmall, gameObject.transform.position, Quaternion.identity);

            Rocket.GetComponent<Rocket_start>().enable_multishot_upgrade(Multishot_time);

            Destroy(this.gameObject);

        }
    }



    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
