using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSquare : MonoBehaviour
{
    public Color defaultColor;
    public Color hoverColor;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Draggable draggable = null;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        draggable = null;
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

    public void GetNPC(Draggable newDraggable) {
        if(draggable) {
            FreeNPC();
        }
        draggable = newDraggable;
    }

    public void FreeNPC() {
        if (draggable) {
            draggable.interactSquare = null;
            draggable.npc.canMove = true;
            draggable = null;
        }
    }

}
