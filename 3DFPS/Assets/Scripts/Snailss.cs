using UnityEngine;

public class Snailss : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float movementSpeed = 5f; // Speed at which the object moves
    public Vector3 teleportLocation; // Location to teleport when staying in one place
    public Vector3 respawnLocation; // Location to respawn when below the specified Y position
    public float timeThreshold = 5f; // Time threshold for teleporting
    public float respawnYPosition = -5f; // Y position threshold for respawning

    private float timeSinceLastMove = 0f; // Time since the snail last moved

    private void Update()
    {
        // Rotate and move towards the player if the playerTransform is set
        if (playerTransform != null)
        {
            // Rotate towards the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToPlayer, Time.deltaTime * movementSpeed);

            // Move towards the player
            transform.position += transform.forward * movementSpeed * Time.deltaTime;

            // Reset time since last move
            timeSinceLastMove = 0f;
        }
        else
        {
            // If playerTransform is not set, increment time since last move
            timeSinceLastMove += Time.deltaTime;

            // Check if the snail has been in one place for the specified time threshold
            if (timeSinceLastMove >= timeThreshold)
            {
                // Teleport to the specified location
                transform.position = teleportLocation;
                timeSinceLastMove = 0f; // Reset time since last move
            }
        }

        // Check if the snail is below the specified Y position
        if (transform.position.y <= respawnYPosition)
        {
            // Respawn at the specified location
            transform.position = respawnLocation;
        }
    }
}
