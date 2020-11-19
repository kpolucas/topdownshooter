using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] int health = 500;

    public void BaseTakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }
}
