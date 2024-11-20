using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab; //ref food
    public float xRange = 2f; //x axis spawn range
    public float yRange = 1f; //y-axis spawn range
    private GameObject currentFood;
    // Start is called before the first frame update
    void Start()
    {
        SpawnFood();
    }
    public void SpawnFood()
    {
        //random position in rnage
        Vector2 spawnPosition = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));
        currentFood = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);

    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
