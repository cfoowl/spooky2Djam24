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
    }


    void Defeat() {
        Debug.LogWarning("Boloss t'as perdu");
    }
   
}
