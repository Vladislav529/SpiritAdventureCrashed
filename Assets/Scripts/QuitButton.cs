using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public WindowManager windowsManager;
    public void OnClick()
    {
        windowsManager.ShowWindow("BasicWindow");
        // Application.Quit();
    }
}   