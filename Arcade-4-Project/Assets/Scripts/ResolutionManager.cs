using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    public void Awake()
    {
        Screen.SetResolution(1280, 720, false, 60);
    }

    public void OnDropDownChanged(Dropdown dropDown)
    {
        Debug.Log("DROP DOWN CHANGED -> " + dropDown.value);
        
        switch (dropDown.value)
        {
            case 0:
                Screen.SetResolution(1280, 720, false, 60);
                break;
            case 1:
                Screen.SetResolution(854, 480, false, 60);
                break;
            case 2:
                Screen.SetResolution(640, 360, false, 60);
                break;
        }
    }
}
