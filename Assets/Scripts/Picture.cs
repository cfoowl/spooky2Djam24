using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Picture : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas = null;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    public Transform originalParent;
    public FormPictureSlot formPictureSlot = null;


    public int ID;
    public int hatIndex;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (canvas == null) {
            canvas = GetComponentInParent<Canvas>();
        }
        if (formPictureSlot != null) {
            formPictureSlot.picture = null;
            formPictureSlot = null;
        }
        canvasGroup.blocksRaycasts = false;
        transform.SetParent(originalParent);
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = Vector2.zero;
    }
    
}
