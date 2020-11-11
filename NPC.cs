using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int mentalHealth = 100;
    public void TakeStress(int stress)
    {
        mentalHealth -= stress;
    }
}
