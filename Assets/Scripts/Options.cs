using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //������ � ������������
using UnityEngine.SceneManagement; //������ �� �������
using UnityEngine.Audio; //������ � �����

public class Options : BaseWindow
{
    public float volume = 0; //���������
    public int quality = 0; //��������
    public bool isFullscreen = false; //������������� �����
	private int currResolutionIndex = 0; //������� ����������

	public AudioMixer audioMixer; //��������� ���������
    public Dropdown resolutionDropdown; //������ � ������������ ��� ����
    private Resolution[] resolutions; //������ ��������� ����������

	public Button saveButton;
	public Button exitButton;

	public void ChangeVolume(float val) //��������� �����
    {
        volume = val;
    }
    public void ChangeResolution(int index) //��������� ����������
    {
        currResolutionIndex = index;
    }
    public void ChangeFullscreenMode(bool val) //��������� ��� ���������� �������������� ������
    {
        isFullscreen = val;
    }
    public void ChangeQuality(int index) //��������� ��������
    {
        quality = index;
    }

	public override void Awake()
	{
		Debug.Log("Options.Awake()");
		base.Awake();
		LoadSettings();
		saveButton.onClick.AddListener(SaveSettings);
		exitButton.onClick.AddListener(ReturnToMain);
	}

	private void ReturnToMain()
	{
		_windowManager.CloseWindow(this);
	}

	public void SaveSettings()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/Settings.dat");
		SaveData data = new SaveData();
		data.savedQuality = quality;
		data.savedResolution = currResolutionIndex;
		data.savedVolume = volume;
		data.savedFullscreen = isFullscreen;
		bf.Serialize(file, data);
		file.Close();
		Debug.Log("Game data saved!");
	}

	public void LoadSettings()
	{
		if (File.Exists(Application.persistentDataPath + "/Settings.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/Settings.dat", FileMode.Open);
			SaveData data = (SaveData)bf.Deserialize(file);
			file.Close();
			quality = data.savedQuality;
			currResolutionIndex = data.savedResolution;
			volume = data.savedVolume;
			isFullscreen = data.savedFullscreen;
			audioMixer.SetFloat("Volume", volume); //��������� ������ ���������
			QualitySettings.SetQualityLevel(quality); //��������� ��������
			Screen.fullScreen = isFullscreen; //��������� ��� ���������� �������������� ������
			Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //��������� ����������
			Debug.Log("Game data loaded!");
		}
		else
        {
			Debug.LogError("There is no save data!");
		}
	}
}

[Serializable]
public class SaveData
{
	public int savedQuality;
	public int savedResolution;
	public float savedVolume;
	public bool savedFullscreen;
}

//public class Options2 : BaseWindow
//{
//	public float volume = 0; //���������
//	public int quality = 0; //��������
//	public bool isFullscreen = false; //������������� �����
//	public AudioMixer audioMixer; //��������� ���������
//	public Dropdown resolutionDropdown; //������ � ������������ ��� ����
//	private Resolution[] resolutions; //������ ��������� ����������
//	private int currResolutionIndex = 0; //������� ����������

//	public void ChangeVolume(float val) //��������� �����
//	{
//		volume = val;
//	}
//	public void ChangeResolution(int index) //��������� ����������
//	{
//		currResolutionIndex = index;
//	}
//	public void ChangeFullscreenMode(bool val) //��������� ��� ���������� �������������� ������
//	{
//		isFullscreen = val;
//	}
//	public void ChangeQuality(int index) //��������� ��������
//	{
//		quality = index;
//	}

//	public void SaveSettings()
//	{
//		audioMixer.SetFloat("MasterVolume", volume); //��������� ������ ���������
//		QualitySettings.SetQualityLevel(quality); //��������� ��������
//		Screen.fullScreen = isFullscreen; //��������� ��� ���������� �������������� ������
//		Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //��������� ����������
//	}

//	public void AutoSettings()
//	{
//		resolutionDropdown.ClearOptions(); //�������� ������ �������
//		resolutions = Screen.resolutions; //��������� ��������� ����������
//		List<string> options = new List<string>(); //�������� ������ �� ���������� ����������

//		for (int i = 0; i < resolutions.Length; i++) //���������� ������ � ������ �����������
//		{
//			string option = resolutions[i].width + " x " + resolutions[i].height; //�������� ������ ��� ������
//			options.Add(option); //���������� ������ � ������

//			if (resolutions[i].Equals(Screen.currentResolution)) //���� ������� ���������� ����� ������������
//			{
//				currResolutionIndex = i; //�� ���������� ��� ������
//			}
//		}

//		resolutionDropdown.AddOptions(options); //���������� ��������� � ���������� ������
//		resolutionDropdown.value = currResolutionIndex; //��������� ������ � ������� �����������
//		resolutionDropdown.RefreshShownValue(); //���������� ������������� ��������
//	}
//}
