using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    float speed;
    GameObject playerBase;

    private void Awake()
    {
        speed = Random.Range(0.7f, 2.6f);
        playerBase = GameObject.Find("PlayerBase");
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerBase.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "PlayerBase")
        {
            playerBase.GetComponent<PlayerBase>().BaseTakeDamage(health);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
