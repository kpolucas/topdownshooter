using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] enum SpawnState { SPAWNING, WAITING, COUNTING};
    
    [System.Serializable]
    [SerializeField] class Wave
    {
        public string name; // name of the wave
        public Transform enemy; // type of enemy to spawn
        public int count; // how much enemies to spawn
        public float rate; // how often spawn (1/rate)
    }

    [SerializeField] Wave[] waves;
    private int nextWave = 0; // index of array waves

    [SerializeField] float timeBetweenWaves = 3f;
    float waveCountdown;

    private float enemySearchCowntdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    [SerializeField] Transform[] spawnPoints;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }
        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("spawning wave" + _wave.name);
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

    bool EnemyIsAlive()
    {
        // check if GO with tag enemy is alive every enemySearchCowntdown seconds
        enemySearchCowntdown -= Time.deltaTime;
        if(enemySearchCowntdown <= 0f)
        {
            enemySearchCowntdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        Debug.Log("WAVEEEEEE" + nextWave);
        if(nextWave +1 > waves.Length -1)
        {
            nextWave = 0;
            Debug.Log("The end");
            Application.Quit();
        } 
        else
        {
            nextWave++;
        }
    }
}
