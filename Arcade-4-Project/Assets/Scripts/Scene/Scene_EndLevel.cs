using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_EndLevel : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("Manager", LoadSceneMode.Single);
    }
}
