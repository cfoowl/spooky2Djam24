using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Vector3 mousePositionOffset;
    public InteractSquare interactSquare = null;
    public NPC npc;

    void Start() {
        npc = gameObject.GetComponent<NPC>();
    }

    private Vector3 GetMouseWorldPosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown() {
        if (Player.instance.canDrag) {
            Cursor.SetCursor(GameflowManager.instance.dragCursor, Vector2.zero, CursorMode.ForceSoftware);
            mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
            Player.instance.isDragging = true;
            if (interactSquare) {
                interactSquare.FreeNPC();
                CameraZoom.instance.ResetZoom();
                Textbubble.instance.HideBubble();
            }
        }
    }

    private void OnMouseDrag() {
        if (Player.instance.canDrag && Player.instance.isDragging) {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }
    }

    private void OnMouseUp() {
        Player.instance.isDragging = false;
        Cursor.SetCursor(GameflowManager.instance.defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
        if (interactSquare) {
            if(interactSquare.type == Player.instance.currentStand) {
                interactSquare.GetNPC(this);
                transform.position = interactSquare.transform.position;
                interactSquare.spriteRenderer.color = interactSquare.defaultColor;
                npc.canMove = false;

                CameraZoom.instance.startZoomCoroutine(interactSquare.transform.position);
            }
        }
    }
}
