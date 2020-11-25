using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public bool hasNPC = false;
    Animator spotAnimator;

    private void Start()
    {
        spotAnimator = GetComponent<Animator>();
        if (hasNPC)
        {
            spotAnimator.SetBool("hasNPC", true);
        }
        else
        {
            spotAnimator.SetBool("hasNPC", false);
        }
    }
}
