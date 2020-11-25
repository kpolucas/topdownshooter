using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int ammo = 1;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            Player player = hitInfo.GetComponent<Player>();
            player.ammo += ammo;
            Destroy(gameObject);
        }
    }
}
