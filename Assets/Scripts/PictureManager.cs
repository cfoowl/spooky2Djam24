using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PictureManager : MonoBehaviour
{
    public static PictureManager instance;
    public List<Picture> pictures = new List<Picture>();
    public List<PictureSlot> slots = new List<PictureSlot>();
    public GameObject prefab;
    void Awake()
    {
        instance = this;
    }

    public bool createPicture(NPC npc) {
        foreach(Picture picture in pictures) {
            if(picture.ID == npc.ID) {
                // TODO
                return false;
            }
        }
        PictureSlot pictureSlot = null;
        foreach (PictureSlot slot in slots) {
            if (!slot.isOccupied) {
                pictureSlot = slot;
                break;
            }
        }
        if (pictureSlot == null) {
            // TODO 
            return false;
        }

        GameObject new_instance = Instantiate(prefab);
        new_instance.transform.SetParent(pictureSlot.gameObject.transform, false);
        pictureSlot.isOccupied = true;
        new_instance.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        Picture newPicture = new_instance.GetComponent<Picture>();
        newPicture.originalParent = pictureSlot.gameObject.transform;
        pictures.Add(newPicture);
        newPicture.ID = npc.ID;
        newPicture.hatIndex = npc.hatIndex;

        //Debug
        new_instance.GetComponentInChildren<TMP_Text>().text = npc.ID.ToString();
        return true;
    }

}
