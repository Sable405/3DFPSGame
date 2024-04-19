using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeIn : MonoBehaviour
{
    public Image imageToFade; // Reference to the Image component to fade in
    public float fadeInDuration = 1.0f; // Duration of the fade-in effect in seconds

    IEnumerator Start()
    {
        // Set the initial alpha of the image to fully transparent
        Color originalColor = imageToFade.color;
        originalColor.a = 0f;
        imageToFade.color = originalColor;

        // Gradually increase the alpha value over time to fade in the image
        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeInDuration); // Ensure t stays between 0 and 1
            Color newColor = imageToFade.color;
            newColor.a = Mathf.Lerp(0f, 1f, t); // Interpolate between fully transparent and fully opaque
            imageToFade.color = newColor;
            yield return null;
        }

        // Ensure the image is fully opaque at the end of the fade-in duration
        Color finalColor = imageToFade.color;
        finalColor.a = 1f;
        imageToFade.color = finalColor;
    }
}
