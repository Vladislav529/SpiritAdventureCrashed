using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{
    public GameObject windowParent;

    public void ShowWindow(string prefabName)
    {
        var prototype = Resources.Load<BaseWindow>("BasicWindow");
        var window = GameObject.Instantiate<BaseWindow>(prototype, windowParent.transform);
        window.closeEvent.AddListener(CloseWindow);
    }

    public void CloseWindow(BaseWindow window)
    {
        Destroy(window.gameObject);
    }
}
