// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class PlayerUI : MonoBehaviour
// {
//     public TextMeshProUGUI experienceText; 
//     public TextMeshProUGUI healthText;
//     public PointCollection collectExperience;
//     public int playerHealth = 100;
//     // Start is called before the first frame update
//     void Start()
//     {
// //        experienceText.text = "XP: " + collectExperience.experiencePoints;
//   //      healthText.text = "Health: " + playerHealth; 
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         experienceText.text = "XP: " + collectExperience.experiencePoints;
//         healthText.text = "Health: " + playerHealth;
//     }
    
//     void OnTriggerEnter2D(Collider2D other)
//     {
//         //check if player collided with collectible
//         if (other.CompareTag("Coral"))
//         {
//             playerHealth = 0; // increase exp points
//             Destroy(other.gameObject); //destroy food
//         }
//     }
//     public void TakeDamage(int damage)
//     {
//         playerHealth -= damage;
//         if (playerHealth <= 0)
//         {
//             //handle death
//             Debug.Log("Player is dead");
//         }
//     }
// }
