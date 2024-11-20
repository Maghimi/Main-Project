using System.Collections;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed at which the enemy moves
    public float changeDirectionTime = 2f; // Time before changing direction
    private Vector2 moveDirection;
    private float timeToChangeDirection;
    public AudioClip death;
    private AudioSource audioSource;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main;
        // Set an initial random direction
        SetRandomDirection();
        timeToChangeDirection = changeDirectionTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //when enemy touches the player, destroy the player
          Destroy(collision.gameObject);
          audioSource.PlayOneShot(death) ; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy in the current direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Count down the time until the enemy changes direction
        timeToChangeDirection -= Time.deltaTime;
        if (timeToChangeDirection <= 0)
        {
            SetRandomDirection(); // Change direction randomly
            timeToChangeDirection = changeDirectionTime; // Reset the timer
        }
        ClampPosition();
    }

    // Function to set a random movement direction
    void SetRandomDirection()
    {
        // Randomize the direction (X and Y axis)
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    void ClampPosition()
    {
        // Get the world position of the camera
        Vector3 screenBounds = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the enemy goes out of bounds and clamp its position
        screenBounds.x = Mathf.Clamp(screenBounds.x, 0f, 1f);
        screenBounds.y = Mathf.Clamp(screenBounds.y, 0f, 1f);

        // Convert back from viewport space to world space
        transform.position = mainCamera.ViewportToWorldPoint(screenBounds);
    }
}