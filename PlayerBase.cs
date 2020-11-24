using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public int health = 500;

    public void BaseTakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }
}
