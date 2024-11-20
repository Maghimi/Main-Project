using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyGuard : MonoBehaviour
{
    public Transform player; // Reference to the player's fish
    public float followDistance = 2f; // Distance to maintain from the player
    public float detectionRange = 5f; // Range to detect predators
    public float speed = 3f; // Movement speed

    void Update()
    {
        FollowPlayer();
        DetectPredators();
    }

    void FollowPlayer()
    {
        // Move towards the player while maintaining a distance
        if (Vector3.Distance(transform.position, player.position) > followDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

   void DetectPredators()
    {
        // Logic to detect predators within the detection range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Predator"))
            {
                Debug.Log("Detected Predator: " + hitCollider.name); // Debug log

                // Calculate the direction towards the predator
                Vector3 direction = (hitCollider.transform.position - transform.position).normalized;

                // Move towards the predator to chase it away
                transform.position += direction * speed * Time.deltaTime;

                // Optionally, you can add a break if you only want to interact with one predator at a time
                // break;
            }
        }
    }
}