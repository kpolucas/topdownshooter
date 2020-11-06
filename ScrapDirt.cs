using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapDirt : MonoBehaviour
{

    public float timeToSpawn = 2f;
    public GameObject ammoCrate;
    float timer;

    private void Start()
    {
        timer = timeToSpawn;
    }

    void Update()
    {
        SpawnBullets();
    }

    void SpawnBullets()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeToSpawn;
            Vector3 closeRandom = Random.insideUnitCircle;
            Instantiate(ammoCrate, (transform.position + closeRandom), Quaternion.identity);
        }
    }
}
