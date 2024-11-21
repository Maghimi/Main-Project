using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointCollection : MonoBehaviour
{
    // set poinst to 0
    public int experiencePoints = 0;
    public int requiredPoints = 3;
    public AudioClip collectSound;
    public Slider experienceSlider;
    private AudioSource audioSource;
    private FoodSpawner foodSpawner;
    private LevelManager levelManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        //check if player collided with collectible
        if (other.CompareTag("Food"))
        {
            // play collection sound
            
            experiencePoints += 1; // increase exp points
            Debug.Log(experiencePoints);
            Destroy(other.gameObject); //destroy food
            audioSource.PlayOneShot(collectSound) ;// play audio
            foodSpawner.SpawnFood();
            //UpdateExperienceBar();
             if (experiencePoints >= requiredPoints)
            {
                // You can change this scene name to whatever the next level's name is.
                levelManager.LevelComplete();
                Debug.Log("Required points reached! Loading next level...");
                //LoadNextLevel();
            }
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //assign audiosource toaudisource
        audioSource = GetComponent<AudioSource>();
        foodSpawner = FindObjectOfType<FoodSpawner>();
        levelManager = FindObjectOfType<LevelManager>();
        experienceSlider.maxValue = requiredPoints;
        UpdateExperienceBar();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateExperienceBar()
    {
        experienceSlider.value = experiencePoints;
    }
    void LoadNextLevel()
    {
        // Get the current scene index and load the next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene exists in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Load the next scene
        }
        else
        {
            Debug.Log("No more levels. You have completed the game!");
            // Optionally, restart the game or go to a game over screen
            SceneManager.LoadScene(0); // Loads the first scene again or you can load a "Game Over" scene
        }
    }
}
