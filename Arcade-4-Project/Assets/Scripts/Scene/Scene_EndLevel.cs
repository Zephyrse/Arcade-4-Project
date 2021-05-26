using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A simple script that loads the "manager" level of the game.
/// </summary>

public class Scene_EndLevel : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
