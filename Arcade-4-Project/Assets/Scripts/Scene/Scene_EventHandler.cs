using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CyberChase.Scoreboards;

/// <summary>
/// A simple script that allows for a scoreboard entry to be added to the scoreboard.
/// </summary>

public class Scene_EventHandler : MonoBehaviour
{
    [SerializeField]
    private Scoreboard scoreboard;

    public void Start()
    {
        scoreboard.AddTestEntry();
        Scene_Score._scoreValue = 0;
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
