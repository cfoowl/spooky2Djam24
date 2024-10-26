using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectionZone : MonoBehaviour
{
    private InteractSquare interactSquare;
    [SerializeField] private EZonesTypes type;

    void Awake() {
        interactSquare = GetComponentInChildren<InteractSquare>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                player.OnZoneEnter(type);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                player.OnZoneExit(type);
                if (interactSquare) {
                    interactSquare.FreeNPC();
                }
            }
        }
    }
    
}
