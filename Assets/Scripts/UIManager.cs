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
        List<string> options = new List<string>();
        options.Add("-- Select a name --");
        options.AddRange(NPCManager.instance.getNameList());
        nameDropdown.AddOptions(options);
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
                    if(folder.pictureID == draggable.npc.ID) {
                        // success
                        draggable.npc.HappyEnd();
                    } else {
                        Debug.Log("Wrong picture");
                    }
                } else {
                    Debug.Log("Wrong cause");
                }
            } else {
                Debug.Log("Wrong name");
            }
        }
    }
    
}
