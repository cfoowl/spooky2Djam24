using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject assemblyUiPanel;
    public GameObject folderUiPanel;
    public TMP_Dropdown nameDropdown;
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
        nameDropdown.ClearOptions();
        nameDropdown.AddOptions(NPCManager.instance.getNameList());
    }
    public void HideAssemblyUIPanel() {
        assemblyUiPanel.SetActive(false);
        Player.instance.canMove = true;
    }
    public void ShowFolderUIPanel() {
        folderUiPanel.SetActive(true);
    }
    public void HideFolderUIPanel() {
        folderUiPanel.SetActive(false);
    }
    
}
