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
            if(!player.hasNPC)
            {
                Animator playerAnimator = hitInfo.GetComponent<Animator>();
                player.hasNPC = true;
                playerAnimator.SetBool("hasNPC", true);
                Destroy(gameObject);
            }
        }
    }
}
