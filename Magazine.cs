using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int magazineSize = 10;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.tag);
        if(hitInfo.tag == "Player")
        {
            Player player = hitInfo.GetComponent<Player>();
            player.ammo += magazineSize;
            Destroy(gameObject);
        }
    }
}
