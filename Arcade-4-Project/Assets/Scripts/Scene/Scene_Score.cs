using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for the constant update of the score counter
/// </summary>

public class Scene_Score : MonoBehaviour
{
    public Transform player;
    public Text scoreMovement;
    public static int _scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        _scoreValue = 0;
    }

    // Update is called once per frame

}
