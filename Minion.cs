using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.tag);
        if (hitInfo.tag == "Player")
        {
            Player player = hitInfo.GetComponent<Player>();
            player.hasNPC = true;
            Destroy(gameObject);
        }
    }
}
