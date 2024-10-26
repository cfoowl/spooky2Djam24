using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Vector3 mousePositionOffset;
    [HideInInspector] public InteractSquare interactSquare = null;

    private Vector3 GetMouseWorldPosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown() {
        if (Player.instance.canDrag) {
            mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
            Player.instance.isDragging = true;
        }
    }

    private void OnMouseDrag() {
        if (Player.instance.canDrag && Player.instance.isDragging) {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }
    }

    private void OnMouseUp() {
        Player.instance.isDragging = false;
        if (interactSquare) {
            transform.position = interactSquare.transform.position;
        }
    }
}
