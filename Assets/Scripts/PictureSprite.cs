using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureSprite : MonoBehaviour
{
    public int hatIndex;
    public int colorIndex;
    public Image hatSpriteRenderer;
    public Image bodySpriteRenderer;
    public Vector2[] hatSpriteOffset;
    public Vector2[] hatSpriteSize;
    public void changeHatSprite(Sprite newHatSprite, int hatIndex) {
        hatSpriteRenderer.sprite = newHatSprite;
        hatSpriteRenderer.GetComponent<RectTransform>().localPosition = hatSpriteOffset[hatIndex];
        hatSpriteRenderer.GetComponent<RectTransform>().sizeDelta = hatSpriteSize[hatIndex];
    }

    public void changeBodySprite(Sprite newBodySprite) {
        bodySpriteRenderer.sprite = newBodySprite;
    }
}
