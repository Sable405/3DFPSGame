using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTouch : MonoBehaviour
{
    // Name of the scene to load
    public string sceneToLoad;

    // Check if the player enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Change the scene
            SceneManager.LoadScene(6);
        }
    }
}
