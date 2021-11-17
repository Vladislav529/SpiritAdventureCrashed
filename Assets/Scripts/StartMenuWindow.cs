using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuWindow : BaseWindow
{
	public Button startButton;
	public Button optionsButton;
	public Button quitButton;

	private void Awake()
	{
		startButton.onClick.AddListener(StartGame);
	}

	private void StartGame()
	{
		SceneManager.LoadScene("Game", LoadSceneMode.Additive);
	}
	private void ShowOptions()
	{
		_windowManager.ShowWindow("Options");
	}
	private void QuitGame()
	{

	}
}
