using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBehavior : MonoBehaviour
{
    public float escapeDistance = 3f; // Distance at which the predator starts to escape
    public float speed = 2f; // Movement speed of the predator
    private Transform bodyguard; // Reference to the bodyguard
    private bool isEscaping = false; // Is the predator currently escaping
    private float escapeCooldown = 1f; // Cooldown time after escaping
    private float lastEscapeTime; // Last time the predator escaped

    void Start()
    {
        // Find the bodyguard in the scene
        bodyguard = GameObject.FindWithTag("BodyGuard").transform;
    }

    void Update()
    {
        // Check if the predator should escape
        if (isEscaping)
        {
            EscapeFromBodyguard();
        }
        else
        {
            MoveTowardPlayer();
        }
    }

    void MoveTowardPlayer()
    {
        // Assume there's a GameObject tagged "Player" to represent the player's fish
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && Time.time > lastEscapeTime + escapeCooldown)
        {
            // Only move toward the player if not escaping
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            transform.position += directionToPlayer * speed * Time.deltaTime;
        }
    }

    void EscapeFromBodyguard()
    {
        // Check if the bodyguard is close enough to escape
        if (bodyguard != null && Vector3.Distance(transform.position, bodyguard.position) < escapeDistance)
        {
            // Move away from the bodyguard
            Vector3 direction = (transform.position - bodyguard.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Set the last escape time to manage cooldown
            lastEscapeTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BodyGuard"))
        {
            isEscaping = true; // Start escaping when the bodyguard is detected
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BodyGuard"))
        {
            isEscaping = false; // Stop escaping when the bodyguard is no longer detected
        }
    }
}