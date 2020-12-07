using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMesh;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkingText());
    }

    public IEnumerator BlinkingText()
    {
        while (true)
        {  
            //set the Text's text to blank
            TextMesh.text = "Insert Coin";
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(1.0f);
            //display “I AM FLASHING TEXT” for the next 0.5 seconds
            TextMesh.text = "";
            yield return new WaitForSeconds(1.0f);
        }
    }
}
