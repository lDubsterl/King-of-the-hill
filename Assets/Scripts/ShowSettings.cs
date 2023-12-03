using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSettings : MonoBehaviour
{
    [SerializeField] Canvas menuCanvas;
    [SerializeField] Canvas myCanvas;

    public void ShowSettingWindow()
    {
        menuCanvas.enabled = false;
        myCanvas.enabled = true;
    }
   
}
