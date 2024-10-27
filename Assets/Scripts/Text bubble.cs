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
        tMP_Text = GetComponentInChildren<TMP_Text>();
    }
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowBubble() {
        gameObject.SetActive(true);
    }

    public void HideBubble() {
        gameObject.SetActive(false);
    }    
}
