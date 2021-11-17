using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{
    public GameObject windowParent;

    public void ShowWindow(string prefabName)
    {
        var prototype = Resources.Load<BaseWindow>(prefabName);
        var window = GameObject.Instantiate<BaseWindow>(prototype, windowParent.transform);
        window.Init(this);
        window.closeEvent.AddListener(CloseWindow);
    }

    public void CloseWindow(BaseWindow window)
    {
        Destroy(window.gameObject);
    }
}
