using System.Data;
using UnityEngine;

public class Zom : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 3f; // Speed at which the enemy moves towards the player
    public float rotationSpeed = 5f; // Speed at which the enemy rotates towards the player
    public float pushForce = 10f; // Force applied to the player upon collision with the enemy
    public PewPewDevice Shoot;

    private bool isKilled = false; // Flag to check if this enemy has been killed

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0f; // Ensure the enemy doesn't tilt upwards or downwards
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
                Vector3 awayFromEnemy = collision.gameObject.transform.position - transform.position;
                awayFromEnemy.Normalize();
                playerRigidbody.AddForce(awayFromEnemy * pushForce, ForceMode.Impulse);
            }
        }
        else if (collision.gameObject.CompareTag("Bullet") && !isKilled)
        {
            isKilled = true; // Mark this enemy as killed
            if (Shoot != null)
            {
                Shoot.Kilt(); // Call the method to increment the kill count
            }
            Destroy(gameObject, 1f); // Destroy the enemy after a short delay
        }
    }
}
