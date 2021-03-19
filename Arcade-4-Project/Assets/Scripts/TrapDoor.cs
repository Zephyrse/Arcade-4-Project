using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    [SerializeField] private GameObject trapdoor;


    private void Start()
    {
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(testFunction());
    }


    public IEnumerator testFunction()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(3);
        trapdoor.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        trapdoor.GetComponent<BoxCollider2D>().enabled = true;


        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }

}

// ---Notes---
// IEnumerator deals with waiting of seconds
// On trigger: start IEnumerator -> disable 2d collider -> 5 seconds later -> enable 2d collider