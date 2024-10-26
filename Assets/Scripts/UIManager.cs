using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject assemblyUiPanel;
    void Awake() {
        instance = this;
    }
    void Start()
    {
        assemblyUiPanel.SetActive(false);
    }

    public void ShowAssemblyUIPanel() {
        assemblyUiPanel.SetActive(true);
        Player.instance.canMove = false;
    }
    public void HideAssemblyUIPanel() {
        assemblyUiPanel.SetActive(false);
        Player.instance.canMove = true;
    }
    
}
