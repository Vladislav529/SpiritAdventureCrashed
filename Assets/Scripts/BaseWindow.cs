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
	protected WindowManager _windowManager;

	public void Init(WindowManager windowManager)
    {
		_windowManager = windowManager;
    }

	private void Awake()
	{
		closeEvent = new UnityEvent<BaseWindow>();
		if (closeButton != null)
		{
			closeButton.onClick.AddListener(() => closeEvent.Invoke(this));
		}
	}
}
