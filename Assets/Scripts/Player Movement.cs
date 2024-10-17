using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //set movespeed
    public float movespeed = 5f;
    private Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse position
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        //move fish towards the target (mouse pos)
        Vector2 currentPosition = transform.position;
        Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, movespeed * Time.fixedDeltaTime);
        transform.position = newPosition;
    }
}
