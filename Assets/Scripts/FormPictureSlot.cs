using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FormPictureSlot : MonoBehaviour, IDropHandler
{
    public GameObject picture = null;
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            if (picture != null) {
                picture.transform.SetParent(picture.GetComponent<Picture>().originalParent, false);
                picture.GetComponent<Picture>().formPictureSlot = null;
                picture.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            picture = eventData.pointerDrag;
            picture.transform.SetParent(transform, false);
            picture.GetComponent<Picture>().formPictureSlot = this;
        }
    }
}
