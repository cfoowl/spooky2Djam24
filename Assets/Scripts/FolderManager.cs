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
    public List<FolderSlot> slots = new List<FolderSlot>();
    public Canvas canvas;

    public void CreateFolder() {
        FolderSlot folderSlot = null;
        foreach (FolderSlot slot in slots) {
            if (!slot.isOccupied) {
                folderSlot = slot;
                break;
            }
        }
        if (folderSlot == null) {
            // TODO 
            return;
        }
        GameObject new_instance = Instantiate(prefab);
        new_instance.transform.SetParent(folderSlot.gameObject.transform, false);
        folderSlot.isOccupied = true;
        new_instance.transform.localScale = Vector3.one;

        Folder folder = new_instance.GetComponent<Folder>();
        folder.originalParent = folderSlot.gameObject.transform;
        folder.nameText.text = dropdown_name.options[dropdown_name.value].text;
        folder.deathCauseText.text = dropdown_death_cause.options[dropdown_death_cause.value].text;
        folder.deathCauses = (EDeathCauses) dropdown_death_cause.value;

        PictureSprite pictureSprite = picture_slot.picture.GetComponent<PictureSprite>();
        folder.pictureSprite.changeBodySprite(PictureManager.instance.defaultSprites[pictureSprite.colorIndex]);
        folder.pictureSprite.changeHatSprite(PictureManager.instance.hatSprites[pictureSprite.hatIndex], pictureSprite.hatIndex);

    }




}
