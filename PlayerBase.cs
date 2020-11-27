using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [Header("Sprite Settings:")]
    public Sprite lowHealth; 
    public Sprite mediumHealth;
    public Sprite fullHealth; 
    [Space]

    public int health = 100;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void BaseTakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("GAME OVER");
        }
        else if (health < 200f)  // <-- Lo ideal seria % y deshardcodearlo
        {
            spriteRenderer.sprite = lowHealth;
        }
        else if (health < 400f)
        {
            spriteRenderer.sprite = mediumHealth;
        }
        else
        {
            spriteRenderer.sprite = fullHealth;
        }
    }
}
