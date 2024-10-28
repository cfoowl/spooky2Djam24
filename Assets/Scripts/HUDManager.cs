using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Image satisfactionFilledBar;
    public Image satisfactionEmptyBar;
    

    void Update()
    {
        satisfactionFilledBar.fillAmount = GameflowManager.instance.satisfaction / (float) GameflowManager.instance.satisfactionMax;
        satisfactionEmptyBar.fillAmount = (GameflowManager.instance.satisfactionMax - GameflowManager.instance.satisfaction) / (float) GameflowManager.instance.satisfactionMax;
    }
}
