using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseText : MonoBehaviour
{
    TextMesh healthTextMesh;
    PlayerBase playerbase;

    void Start()
    {
        healthTextMesh = GetComponent<TextMesh>();
        playerbase = GetComponentInParent<PlayerBase>();
    }
    void Update()
    {
        healthTextMesh.text = playerbase.health.ToString(); // <-- every frame esta bien? o disparar solo cuando cambie?
    }
}
