using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Required for using the UI Image component

public class ImagePopupController : MonoBehaviour
{
    [Header("UI Components")]
    public Image popupImage;

    [Header("Settings")]
    public float visibleDuration = 2.0f; // How long the image stays fully visible
    public float fadeDuration = 1.0f;    // How long it takes to fade away

    // Call this method from another script or a button to trigger the effect
    public void TriggerPopup()
    {
        // Stop any running popups before starting a new one
        StopAllCoroutines();
        StartCoroutine(PopupRoutine());
    }

    private IEnumerator PopupRoutine()
    {
        // 1. POP UP: Make image fully visible instantly
        Color originalColor = popupImage.color;
        popupImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
        popupImage.enabled = true;

        // 2. WAIT: Keep it on screen for the specified duration
        yield return new WaitForSeconds(visibleDuration);

        // 3. FADE AWAY: Gradually decrease the alpha to 0
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            
            // Calculate current alpha over time
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            popupImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            
            yield return null; // Wait until the next frame
        }

        // Ensure it is completely hidden and turned off at the end
        popupImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        popupImage.enabled = false;
    }
}
