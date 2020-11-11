using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapDirt : MonoBehaviour
{
    public float timeToSpawn = 5f;
    public GameObject ammoCrate;
    float timer;
    Spot spot;

    void Start()
    {
        timer = timeToSpawn;
        spot = gameObject.GetComponent<Spot>();
    }

    void Update()
    {
        if (spot.hasNPC)
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
            if(ammoCrate) // evita una missingreference Random
            {
                Instantiate(ammoCrate, (transform.position + new Vector3(1.7f, -0.5f, 0)), Quaternion.identity);
            }
        }
    }
}
