using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject intermissionScreen; // Reference to the intermission screen (for hiding/showing)
    
    // Call this method when the level is complete to show the intermission screen
    public void LevelComplete()
    {
        intermissionScreen.SetActive(true); // Show the intermission screen
        Time.timeScale = 0; // Pause the game
    }

    // Method to load the next level
    //
    public void NextLevel()
    {
        Time.timeScale = 1; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load next level
    }

    // Method to replay the current level
    public void ReplayLevel()
    {
        Time.timeScale = 1; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current level
    }
}
