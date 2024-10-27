using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Folder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text nameText;
    public TMP_Text deathCauseText;
    public Vector3 defaultScale = Vector3.one;
    public Vector3 highlightScale = Vector3.one * 1.2f;

    public void OnPointerEnter(PointerEventData eventData) {
        transform.localScale = highlightScale;
    }

    public void OnPointerExit(PointerEventData eventData) {
        transform.localScale = defaultScale;
    }

}
