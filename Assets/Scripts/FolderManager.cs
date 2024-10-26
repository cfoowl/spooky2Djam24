using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FolderManager : MonoBehaviour
{
    public FormPictureSlot picture_slot;
    public TMP_Dropdown dropdown_name;
    public TMP_Dropdown dropdown_death_cause;
    public GameObject prefab;
    public List<Folder> folders = new List<Folder>();
    public Canvas canvas;

    public void CreateFolder() {
        if (folders.Count >= 4) {
            //TODO
            return;
        }
        GameObject new_instance = Instantiate(prefab);
        new_instance.transform.SetParent(canvas.transform);
        new_instance.transform.localScale = Vector3.one;

        Folder folder = new_instance.GetComponent<Folder>();
        folder.nameText.text = dropdown_name.options[dropdown_name.value].text;
        folder.deathCauseText.text = dropdown_death_cause.options[dropdown_death_cause.value].text;
        

    }




}
