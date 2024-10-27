using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameflowManager : MonoBehaviour
{
    public static GameflowManager instance;
    public int satisfactionStart = 5;
    public int satisfactionMax  = 15;
    public int satisfaction;

    public Texture2D defaultCursor;
    public Texture2D dragCursor;

    void Awake() {
        instance = this;
        satisfaction = satisfactionStart;
    }

    public void UpdateSatisfaction(int delta) {
        satisfaction += delta;
        if (satisfaction <= 0) {
            Defeat();
        } else if(satisfaction >= satisfactionMax) {
            satisfaction = satisfactionMax;
        }

        if (satisfaction >= 5) {
            MusicManager.instance.ChangBGM(1);
        } else if (satisfaction >= 3) {
            MusicManager.instance.ChangBGM(2);
        } else if (satisfaction >= 1) {
            MusicManager.instance.ChangBGM(3);
        }
    }


    void Defeat() {
        Debug.LogWarning("Boloss t'as perdu");
    }
   
}
