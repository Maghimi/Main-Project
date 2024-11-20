using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;     // Array of waypoints for patrol
    public float patrolSpeed = 2f;    // Speed of the enemy while patrolling
    public float chaseSpeed = 4f;     // Speed of the enemy while chasing
    public float detectionRadius = 5f; // Distance to start chasing the player
    public Transform player;          // Reference to the player
       public AudioClip death;
    private AudioSource audioSource;

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool isChasing = false;       // Check if the enemy is chasing

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
      //  halfScreenY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)).y;
    }
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            isChasing = true; // Start chasing the player if within detection radius
        }
        else
        {
            isChasing = false; // Return to patrol if player is out of range
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

        // Check if reached the waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Move to the next waypoint, looping back if needed
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void ChasePlayer()
    {
        // Move towards the player’s position
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a sphere in the Scene view to show the detection radius
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

