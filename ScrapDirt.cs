﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapDirt : MonoBehaviour
{

    public float timeToSpawn = 5f;
    public GameObject ammoCrate;
    float timer;
    public bool active = true;

    void Start()
    {
        timer = timeToSpawn;
    }

    void Update()
    {
        if(active)
        {
            SpawnBullets();
        }
    }

    void SpawnBullets()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeToSpawn;
            Instantiate(ammoCrate, (transform.position + new Vector3(1.7f,-0.5f,0)), Quaternion.identity);
        }
    }
}
