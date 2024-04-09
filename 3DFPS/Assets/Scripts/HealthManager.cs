using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthBar; // Reference to the UI slider representing the health
    private float currentHealth;

    void Start()
    {
        // Initialize health to the max value of the slider
        currentHealth = healthBar.maxValue;
        UpdateHealthUI();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged as "Bullet"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Decrease health by 1
            currentHealth -= 1;
            UpdateHealthUI();

            // Optionally, destroy the bullet
            Destroy(collision.gameObject);

            // Check for zero or negative health
            if (currentHealth <= 0)
            {
                Debug.Log("Health is depleted!");
                // Handle the object's destruction or disable it, as needed
                // gameObject.SetActive(false); // Example: Disable the object
                // Destroy(gameObject); // Example: Destroy the object
                Destroy(this.gameObject);
            }
        }
    }

    void UpdateHealthUI()
    {
        // Update the UI Slider's value
        healthBar.value = currentHealth;
    }
}
