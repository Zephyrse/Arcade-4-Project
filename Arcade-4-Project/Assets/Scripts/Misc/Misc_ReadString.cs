using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Misc_ReadString : MonoBehaviour
{
    public static string nInput;

    public TextMeshProUGUI text;
    public GameObject Menus;

    public void AcceptInput()
    {
        nInput = text.text.ToString();
        Debug.Log(nInput);

        gameObject.SetActive(false);
        Menus.SetActive(true);

    }

    public void ReadString(string s)
    {
        //input = s;
        //Debug.Log(input);
    }
}
