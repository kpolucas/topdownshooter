using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int ammo = 50;
    Collider2D col = null;

    private void Update()
    {
        if(col != null)
        {
            if(Input.GetKeyDown("r") && ammo > 0)
            {
                RefillAmmo(col);
            }
            if(Input.GetKeyDown("e"))
            {
                GrabNPC(col);
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
        NPCWeapon spot = _col.gameObject.GetComponent<NPCWeapon>();
        spot.ammo++;
        ammo--;
    }

    void GrabNPC(Collider2D _col)
    {
        Debug.Log("grabNPC");
    }
}
