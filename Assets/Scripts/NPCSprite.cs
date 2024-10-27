using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSprite : MonoBehaviour
{
    public SpriteRenderer hatSpriteRenderer;
    public SpriteRenderer bodySpriteRenderer;
    public Vector2[] hatSpriteOffset;

    public void changeHatSprite(Sprite newHatSprite, int hatIndex) {
        hatSpriteRenderer.sprite = newHatSprite;
        hatSpriteRenderer.transform.localPosition = hatSpriteOffset[hatIndex];
    }

}
