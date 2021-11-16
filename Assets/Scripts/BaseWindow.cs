using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BaseWindow : MonoBehaviour
{
    public Button closeButton;

    [HideInInspector]
    public UnityEvent<BaseWindow> closeEvent { get; private set; }

    private void Awake()
    {
        closeEvent = new UnityEvent<BaseWindow>();
        closeButton.onClick.AddListener(() => closeEvent.Invoke(this));
    }
}
