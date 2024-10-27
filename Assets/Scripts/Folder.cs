using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Folder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas = null;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    public Transform originalParent;
    public TMP_Text nameText;
    public TMP_Text deathCauseText;
    public EDeathCauses deathCauses;
    public Vector3 defaultScale = Vector3.one;
    public Vector3 highlightScale = Vector3.one * 1.2f;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
       rectTransform.localScale = highlightScale;
    }

    public void OnPointerExit(PointerEventData eventData) {
        rectTransform.localScale = defaultScale;
    }
    public void OnBeginDrag(PointerEventData eventData) {
        if (canvas == null) {
            canvas = GetComponentInParent<Canvas>();
        }
        // if (returnFolderSlot != null) {
        //     returnFolderSlot.picture = null;
        //     returnFolderSlot = null;
        // }
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
