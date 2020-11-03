using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int ammo = 50;

    private void OnCollisionStay2D(Collision2D col)
    {
        if(Input.GetKeyDown("R") && col.gameObject.tag == "Spot")
        {
            RefillAmmo(col);
        }
    }

    void RefillAmmo(Collision2D _col)
    {
        NPCWeapon spot = _col.gameObject.GetComponent<NPCWeapon>();
        spot.ammo++;
        ammo--;
        Debug.Log(ammo);
    }
}
