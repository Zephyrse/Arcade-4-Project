using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_TrapDoor : MonoBehaviour
{
    [SerializeField] private GameObject trapdoor;
    [SerializeField] private Animator v_Animator;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TestFunction());
    }


    public IEnumerator TestFunction()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        v_Animator.SetTrigger("PlayerStep");


        yield return new WaitForSeconds(1);
        trapdoor.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        trapdoor.GetComponent<BoxCollider2D>().enabled = true;

        v_Animator.ResetTrigger("PlayerStep");

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        StopCoroutine(TestFunction());
    }

}

// ---Notes---
// IEnumerator deals with waiting of seconds
// On trigger: start IEnumerator -> disable 2d collider -> 5 seconds later -> enable 2d collider