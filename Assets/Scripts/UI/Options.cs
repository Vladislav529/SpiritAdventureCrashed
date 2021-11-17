using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //������ � ������������
using UnityEngine.SceneManagement; //������ �� �������
using UnityEngine.Audio; //������ � �����

public class Options : MonoBehaviour
{
    public float volume = 0; //���������
    public int quality = 0; //��������
    public bool isFullscreen = false; //������������� �����
    public AudioMixer audioMixer; //��������� ���������
    public Dropdown resolutionDropdown; //������ � ������������ ��� ����
    private Resolution[] resolutions; //������ ��������� ����������
    private int currResolutionIndex = 0; //������� ����������

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

    public void SaveSettings()
    {
        audioMixer.SetFloat("MasterVolume", volume); //��������� ������ ���������
        QualitySettings.SetQualityLevel(quality); //��������� ��������
        Screen.fullScreen = isFullscreen; //��������� ��� ���������� �������������� ������
        Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen); //��������� ����������
    }

    public void AutoSettings()
    {
        resolutionDropdown.ClearOptions(); //�������� ������ �������
        resolutions = Screen.resolutions; //��������� ��������� ����������
        List<string> options = new List<string>(); //�������� ������ �� ���������� ����������

        for (int i = 0; i < resolutions.Length; i++) //���������� ������ � ������ �����������
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //�������� ������ ��� ������
            options.Add(option); //���������� ������ � ������

            if (resolutions[i].Equals(Screen.currentResolution)) //���� ������� ���������� ����� ������������
            {
                currResolutionIndex = i; //�� ���������� ��� ������
            }
        }

        resolutionDropdown.AddOptions(options); //���������� ��������� � ���������� ������
        resolutionDropdown.value = currResolutionIndex; //��������� ������ � ������� �����������
        resolutionDropdown.RefreshShownValue(); //���������� ������������� ��������
    }
}
