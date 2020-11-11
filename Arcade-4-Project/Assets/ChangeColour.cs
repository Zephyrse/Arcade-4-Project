using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class ChangeColour : MonoBehaviour
{
    public SpriteRenderer   spriteRenderer;
    public Rigidbody2D      rigidBody;
    public Vector2          movement;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer != null)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value);

            spriteRenderer.color = newColor;

        }

        //if (rigidBody.velocity.x >= 3)
        //{
        //    rigidBody.velocity = movement;
        //    Debug.Log("Changing Velocity");
        //};

    }

    void FixedUpdate()
    {
        float moveHorizontal =  Input.GetAxis("Horizontal");
        float moveVertical   =  Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical);

        rigidBody.AddForce(movement * speed);

    }


}
