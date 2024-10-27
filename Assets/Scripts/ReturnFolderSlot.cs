using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnFolderSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            Folder folder = eventData.pointerDrag.GetComponent<Folder>();
            UIManager.instance.HideFolderUIPanel();
            CameraZoom.instance.ResetZoom();
            folder.originalParent.gameObject.GetComponent<FolderSlot>().isOccupied = false;
            Destroy(folder.gameObject);
        }
    }
}
