using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollection : MonoBehaviour
{
    // set poinst to 0
    public int experiencePoints = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        //check if player collided with collectible
        if (other.CompareTag("Food"))
        {
            
            experiencePoints += 10; // increase exp points
            Debug.Log(experiencePoints);
            Destroy(other.gameObject); //destroy food
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
