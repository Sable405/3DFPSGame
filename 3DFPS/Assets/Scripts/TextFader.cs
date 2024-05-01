using UnityEngine;
using TMPro;
using System.Collections;

public class TextFader : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Reference to the TextMeshPro Text component
    public float fadeDuration = 2f; // Duration of the fade-out effect in seconds

    void Start()
    {
        if (textMeshPro != null)
        {
            StartCoroutine(FadeText());
        }
    }

    IEnumerator FadeText()
    {
        // Get the original color of the text
        Color originalColor = textMeshPro.color;

        // Gradually decrease the alpha value over time to fade out the text
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration); // Ensure t stays between 0 and 1
            Color newColor = originalColor;
            newColor.a = Mathf.Lerp(originalColor.a, 0f, t); // Interpolate between original alpha and fully transparent
            textMeshPro.color = newColor;
            yield return null;
        }

        // Ensure the text is fully transparent at the end of the fade-out duration
        Color finalColor = originalColor;
        finalColor.a = 0f;
        textMeshPro.color = finalColor;

        // Disable the GameObject after fading
        gameObject.SetActive(false);
    }
}
