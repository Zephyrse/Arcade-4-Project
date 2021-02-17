using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //scoreEnemies.text = 0.ToString("0");
        //scoreText.text = scoreMovement.text.ToInt + scoreEnemies.text.ToInt;
    }
}
