using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WindowManager : MonoBehaviour
{
    public GameObject windowParent;
    private List<BaseWindow> openedWindows = new List<BaseWindow>();

    public void ShowWindow(string prefabName)
    {
        var prototype = Resources.Load<BaseWindow>(prefabName);
        var window = GameObject.Instantiate<BaseWindow>(prototype, windowParent.transform);
        if (openedWindows.Any(w => w.GetType() == window.GetType())) return;
        window.Init(this);
        window.closeEvent.AddListener(CloseWindow);
        if (openedWindows.Count > 0)
        {
            CollapseWindow(openedWindows[openedWindows.Count - 1]);
        }
        openedWindows.Add(window);
    }

    public void CloseWindow(BaseWindow window)
    {
        Destroy(window.gameObject);
        openedWindows.Remove(window);
        if (openedWindows.Count > 0)
        {
            ExpandWindow(openedWindows[openedWindows.Count - 1]);
        }
    }

    public void ExpandWindow(BaseWindow window)
    {
        window.gameObject.SetActive(true);
    }

    public void CollapseWindow(BaseWindow window)
    {
        window.gameObject.SetActive(false);
    }
}
