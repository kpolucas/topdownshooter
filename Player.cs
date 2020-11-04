using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int ammo = 50;

    void OnTriggerStay2D(Collider2D col) 
    {
        if(Input.GetKeyDown("space") && col.gameObject.tag == "Spot" && ammo > 0)  // <- Funciona pero a veces si a veces no
        {
            RefillAmmo(col);
        }
    }

    void RefillAmmo(Collider2D _col)
    {
        NPCWeapon spot = _col.gameObject.GetComponent<NPCWeapon>();
        spot.ammo++;
        ammo--;
        Debug.Log(ammo);
    }
}
