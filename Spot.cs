using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public bool hasNPC = false;
    public int health = 100;

    public bool IsBroken()
    {
        if(health <= 0)
        {
            health = 0;
            return true;
        }
        return false;
    }
}
