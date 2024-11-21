using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; // Assign the Game Over UI Canvas in the Inspector
    private bool isGameOver = false;

    void Update()
    {
        // Check if the game is over and the player presses Enter
        if (isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }

    // Call this method when the player dies
    public void TriggerGameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true); // Show the Game Over screen
        Time.timeScale = 0f; // Pause the game
    }

    private void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}