using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    TextMesh ammoTextMesh;
    NPCWeapon npcweapon;

    void Start()
    {
        ammoTextMesh = GetComponent<TextMesh>();
        npcweapon = GetComponentInParent<NPCWeapon>();
    }
    void Update()
    {
        ammoTextMesh.text = npcweapon.ammo.ToString();
    }
}
