using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    float speed;
    Transform playerBase;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        speed = Random.Range(0.7f, 2.6f);
        playerBase = GameObject.Find("PlayerBase").transform;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerBase.position, speed * Time.deltaTime);
    }
}
