using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSquare : MonoBehaviour
{
    public Color defaultColor;
    public Color hoverColor;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("NPC"))
        {
            spriteRenderer.color = hoverColor;
            collider.gameObject.GetComponent<Draggable>().interactSquare = this;    
        }
        
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("NPC"))
        {
            spriteRenderer.color = defaultColor;
            collider.gameObject.GetComponent<Draggable>().interactSquare = null;    
        }
        
    }

}
