using UnityEngine;

public class FollowerEnemy : MonoBehaviour
{
    public Transform leader;          // Assign the leader's transform in the Inspector
    public float followDistance = 2f; // Distance to maintain from the leader
       public AudioClip death;
    private AudioSource audioSource;
    public float speed = 3f;          // Speed of the follower
     void Start()
    {
        audioSource = GetComponent<AudioSource>();
      //  halfScreenY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)).y;
    }

    void Update()
    {
        // Calculate the distance to the leader
        float distanceToLeader = Vector3.Distance(transform.position, leader.position);

        // Move towards the leader if beyond follow distance
        if (distanceToLeader > followDistance)
        {
            // Move towards the leader, not the player
            transform.position = Vector3.MoveTowards(transform.position, leader.position, speed * Time.deltaTime);
        }
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
