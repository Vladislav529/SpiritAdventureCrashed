using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    public void OnClick()
    {
        Application.LoadLevel("Options");
    }
}
