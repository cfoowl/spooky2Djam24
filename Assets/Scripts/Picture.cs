using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Picture : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas = null;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    public Transform originalParent;
    public FormPictureSlot formPictureSlot = null;


    public PictureSprite pictureSprite;
    public int ID;

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

    public void Delete() {
        if (formPictureSlot) {
            formPictureSlot.picture = null;
        }
        PictureManager.instance.pictures.Remove(this);
        originalParent.GetComponent<PictureSlot>().isOccupied = false;
        Destroy(gameObject);
    }
    
}
