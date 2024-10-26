using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectionZone : MonoBehaviour
{
    [SerializeField] private EZonesTypes type;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                player.OnZoneEnter(type);
            }
        } else {
            Debug.Log(collider.tag);
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
            }
        }
    }
}
