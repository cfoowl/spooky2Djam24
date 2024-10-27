using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Textbubble : MonoBehaviour
{
    public static Textbubble instance;
    public TMP_Text tMP_Text;
    void Awake() {
        instance = this;
    }
    void Start()
    {
        gameObject.SetActive(false);
        tMP_Text = GetComponentInChildren<TMP_Text>();
    }

    public void ShowBubble() {
        gameObject.SetActive(true);
    }

    public void HideBubble() {
        gameObject.SetActive(false);
    }    
}
