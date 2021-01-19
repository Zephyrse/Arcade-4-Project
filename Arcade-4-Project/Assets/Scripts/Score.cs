
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    public Text scoreMovement;
    public Text scoreEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        scoreMovement.text = ((player.position.x+10)*10).ToString("0");
        scoreEnemies.text = 0.ToString("0");
        //scoreText.text = scoreMovement.text.ToInt + scoreEnemies.text.ToInt;
    }
}
