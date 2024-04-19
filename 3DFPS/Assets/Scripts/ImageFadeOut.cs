using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageFadeOut : MonoBehaviour
{
    public Image imageToFade; // Reference to the Image component to fade out
    public float fadeOutDuration = 1.0f; // Duration of the fade-out effect in seconds

    IEnumerator Start()
    {
        // Gradually decrease the alpha value over time to fade out the image
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeOutDuration); // Ensure t stays between 0 and 1
            Color newColor = imageToFade.color;
            newColor.a = Mathf.Lerp(1f, 0f, t); // Interpolate between fully opaque and fully transparent
            imageToFade.color = newColor;
            yield return null;
        }

        // Ensure the image is fully transparent at the end of the fade-out duration
        Color finalColor = imageToFade.color;
        finalColor.a = 0f;
        imageToFade.color = finalColor;
    }
}
