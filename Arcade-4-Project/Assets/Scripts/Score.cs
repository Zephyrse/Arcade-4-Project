using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for the constant update of the score counter
/// </summary>

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreMovement;
    public int _scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreMovement.text = (_scoreValue).ToString("0");
    }
}
