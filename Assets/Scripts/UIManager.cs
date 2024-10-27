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
    public Draggable draggable = null;
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
    public void ShowFolderUIPanel(Draggable draggable) {
        this.draggable = draggable;
        folderUiPanel.SetActive(true);
    }
    public void HideFolderUIPanel() {
        this.draggable = null;
        folderUiPanel.SetActive(false);
    }
    public void ReturnFolder(Folder folder) {
        if(draggable) {
            if (folder.nameText.text == draggable.npc.IDname) {
                if(folder.deathCauses == draggable.npc.deathCause){
                    // success
                    draggable.npc.HappyEnd();
                }
                
            } else {
                Debug.Log("Bad name");
            }
        }
    }
    
}
