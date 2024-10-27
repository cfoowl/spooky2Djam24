using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSquare : MonoBehaviour
{
    public Color defaultColor;
    public Color hoverColor;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Draggable draggable = null;
    public EZonesTypes type;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        draggable = null;
        type = GetComponentInParent<DetectionZone>().type;
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
        Action();
    }

    public void FreeNPC() {
        if (draggable) {
            CameraZoom.instance.ResetZoom();
            draggable.interactSquare = null;
            draggable.npc.canMove = true;
            draggable = null;
        }
    }
    public void Action() {
        switch(type) {
            case EZonesTypes.HOME:
                Textbubble.instance.tMP_Text.text = draggable.npc.sentence;
                Textbubble.instance.ShowBubble();
                break;
            case EZonesTypes.PHOTO:
                PictureManager.instance.createPicture(draggable.npc);
                break;
            default:
                break;
        }
    }

}
