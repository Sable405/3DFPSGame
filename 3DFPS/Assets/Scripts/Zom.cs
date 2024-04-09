using System.Data;
using UnityEngine;

public class Zom : MonoBehaviour
{
   // public GameObject Gunt;
    public PewPewDevice Shoot;
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed at which the enemy moves towards the player
    public float rotationSpeed = 5f; // Speed at which the enemy rotates towards the player
    public float pushForce = 10f; // Force applied to the player upon collision with the enemy

void Start()
{
    GameObject Gunt = GameObject.Find("Gun_Rifle");
}
    void Update()
    {
       
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // Calculate the direction away from the enemy
                Vector3 awayFromEnemy = collision.gameObject.transform.position - transform.position;
                // Normalize the direction
                awayFromEnemy = awayFromEnemy.normalized;
                // Apply force to push the player away from the enemy
                playerRigidbody.AddForce(awayFromEnemy * pushForce, ForceMode.Impulse);
            }
        }
         if(collision.gameObject.CompareTag("Bullet"))
        {
            Shoot.Kilt(); 
            Destroy(this.gameObject, 1f); 
        }
    }
    
}
