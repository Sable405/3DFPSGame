using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public Slider healthBar; // Reference to the UI slider representing the health
    public float fillSpeed = 1f; // Speed at which the health bar fills up

    private float currentHealth;
    private float targetHealth;

    void Start()
    {
        // Initialize health to 1
        currentHealth = 1f;
        targetHealth = healthBar.maxValue;
        StartCoroutine(FillHealthBar());
    }

    IEnumerator FillHealthBar()
    {
        while (currentHealth < targetHealth)
        {
            // Increase current health over time until it reaches the target health
            currentHealth += fillSpeed * Time.deltaTime;
            UpdateHealthUI();
            yield return null;
        }

        // Ensure current health is exactly the target health
        currentHealth = targetHealth;
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
                SceneManager.LoadScene(5);
            }
        }
    }

    void UpdateHealthUI()
    {
        // Update the UI Slider's value
        healthBar.value = currentHealth;
    }
}
