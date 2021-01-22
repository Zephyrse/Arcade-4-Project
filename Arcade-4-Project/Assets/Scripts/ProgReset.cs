using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset() //reset highscore function
    {
        PlayerPrefs.DeleteKey("ProgMem");
    }
}
