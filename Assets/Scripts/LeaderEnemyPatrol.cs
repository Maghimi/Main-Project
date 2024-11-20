using UnityEngine;

public class LeaderEnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; // Patrol waypoints
    public float patrolSpeed = 2f; // Speed during patrol
    public float chaseSpeed = 4f;  // Speed during chase
    public float detectionRadius = 5f; // Range to detect player
    public Transform player; // Reference to the player
       public AudioClip death;
    private AudioSource audioSource;
    public float followDistance = 2f; // Distance followers should keep from the leader

    private int currentWaypointIndex = 0; // Current waypoint index
    private bool isChasing = false; // Determines if the enemy is chasing the player
     void Start()
    {
        audioSource = GetComponent<AudioSource>();
      //  halfScreenY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)).y;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within detection range
        if (distanceToPlayer <= detectionRadius)
        {
            isChasing = true; // Start chasing the player
        }
        else
        {
            isChasing = false; // Return to patrol if out of range
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        // Move towards the current waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, patrolSpeed * Time.deltaTime);

        // If the leader reaches the waypoint, move to the next one
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void ChasePlayer()
    {
        // Move towards the player's position
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        // Draw the detection radius for visualization in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
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
}
