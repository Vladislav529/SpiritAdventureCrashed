using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Options");
    }
}
