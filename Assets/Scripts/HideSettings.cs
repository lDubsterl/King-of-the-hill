using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSettings : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas;
    [SerializeField] Canvas myCanvas;

    public void HideSettingWindow()
    { 
        myCanvas.enabled = false;
        menuCanvas.enabled = true;
       
    }
}
