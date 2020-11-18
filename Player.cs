using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int ammo = 50;
    public bool hasNPC = true;
    public Animator animator;

    Collider2D col = null;
    private void Update()
    {
        if(col != null)
        {
            if(Input.GetKeyDown("r") && col.tag=="Spot")
            {
                RefillAmmo(col);
            }
            if(Input.GetKeyDown("e") && col.tag=="Spot")
            {
                NPCInteraction(col);
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        col = collision;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        col = null;
    }

    void RefillAmmo(Collider2D _col)
    {
        if (ammo > 0 && _col.gameObject.GetComponent<NPCWeapon>())
        {
            NPCWeapon npcweapon = _col.gameObject.GetComponent<NPCWeapon>();
            npcweapon.ammo++;
            ammo--;
        }
    }

    void NPCInteraction(Collider2D _col)
    {
        Spot spot = _col.gameObject.GetComponent<Spot>();
        Animator spotAnimator = _col.gameObject.GetComponent<Animator>();
        if (hasNPC && !spot.hasNPC)
        {
            hasNPC = false;
            spot.hasNPC = true;

            animator.SetBool("hasNPC", false);
            spotAnimator.SetBool("hasNPC", true);
        } 
        else if(!hasNPC && spot.hasNPC)
        {
            hasNPC = true;
            spot.hasNPC = false;

            animator.SetBool("hasNPC", true);
            spotAnimator.SetBool("hasNPC", false);
        }
    }
}
