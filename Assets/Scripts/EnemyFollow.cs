using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Player; //reference player
    public float speed = 2f; //speed of the enemy movement
    public AudioClip death;
    private AudioSource audioSource;
    private float halfScreenY = 0;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        halfScreenY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Player != null)
        // {
        //     //if player exists move towrds player
        //     Vector2 direction = (Player.position - transform.position).normalized;
        //     transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        // }
        if (transform.position.y > halfScreenY)
    {
        // Enemy in the top half, move towards the player
        Vector3 direction = (Player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
     else// (transform.position.y >= halfScreenY)
        {
            // Enemy in the top half, move downwards until it re-enters the bottom half
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //when enemy touches the player, destroy the player
          Destroy(collision.gameObject);
          audioSource.PlayOneShot(death) ; 
          FindObjectOfType<GameOverManager>().TriggerGameOver();
        }
    }
    //  private void OnEnable()
    // {
    //     // Spawn enemy only in the top half
    //     float spawnX = Random.Range(-10f, 10f); // Adjust based on screen width
    //     float spawnY = Random.Range(halfScreenY, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);
    //     transform.position = new Vector3(spawnX, spawnY, 0);
    // }
}
