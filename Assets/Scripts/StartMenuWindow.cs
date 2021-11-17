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


	public override void Awake() 
	{
		base.Awake();
		startButton.onClick.AddListener(StartGame);
		optionsButton.onClick.AddListener(ShowOptions);
	}

	private void StartGame()
	{
		SceneManager.LoadScene("Game", LoadSceneMode.Additive); // LoadSceneMode.Additive
		_windowManager.CloseWindow(this);
	}
	private void ShowOptions()
	{
		_windowManager.ShowWindow("OptionsMenu");
	}
	private void QuitGame()
	{

	}
}
