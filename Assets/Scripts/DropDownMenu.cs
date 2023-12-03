using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownMenu : MonoBehaviour
{
    int width = 1280;
    int height = 720;
    bool isFullScreen = true;
    

    public void ResChange(int value)
    {
        if(value == 0)
        {
            height = 1080;
            width = 1920;
        }

        if (value == 1)
        {
            width = 1280;
            height = 720;
        }

        if (value == 2)
        {
            width = 640;
            height = 480;
        }
    }

    public void FullScreentChangeChange(bool fs)
    {
        if(fs == true)
            isFullScreen = fs;
        else
            isFullScreen = false;

    }

    public void ApplyChanges()
    {
        Screen.SetResolution(width, height, isFullScreen);
    }
}
