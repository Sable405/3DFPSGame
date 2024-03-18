using UnityEngine;

public class Snailss : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float movementSpeed = 5f; // Speed at which the object moves

    private void Update()
    {
        if (playerTransform != null)
        {
            // Rotate towards the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToPlayer, Time.deltaTime * movementSpeed);

            // Move towards the player
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }
}
