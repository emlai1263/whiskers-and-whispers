using System.Collections;
using UnityEngine;

public class BgTransition : MonoBehaviour
{
    public float transitionDuration = 1.0f; // Duration of the transition in seconds
    public Renderer currentBackgroundRenderer; // Reference to the renderer of the current background
    public Renderer nextBackgroundRenderer; // Reference to the renderer of the next background


    public void StartTransition()
    {
        StartCoroutine(TransitionCoroutine());
    }

    private IEnumerator TransitionCoroutine()
    {
        // Ensure both backgrounds are active
        currentBackgroundRenderer.gameObject.SetActive(true);
        nextBackgroundRenderer.gameObject.SetActive(true);

        // Set the initial alpha values
        Color currentColor = currentBackgroundRenderer.material.color;
        Color nextColor = nextBackgroundRenderer.material.color;
        currentColor.a = 1.0f;
        nextColor.a = 0.0f;
        currentBackgroundRenderer.material.color = currentColor;
        nextBackgroundRenderer.material.color = nextColor;

        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            // Calculate the new alpha values
            float currentAlpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / transitionDuration);
            float nextAlpha = Mathf.Lerp(0.0f, 1.0f, elapsedTime / transitionDuration);

            // Update the alpha values
            currentColor.a = currentAlpha;
            nextColor.a = nextAlpha;
            currentBackgroundRenderer.material.color = currentColor;
            nextBackgroundRenderer.material.color = nextColor;

            // Wait for the next frame
            yield return null;

            // Update the elapsed time
            elapsedTime += Time.deltaTime;
        }

        // Ensure the transition is complete
        currentColor.a = 0.0f;
        nextColor.a = 1.0f;
        currentBackgroundRenderer.material.color = currentColor;
        nextBackgroundRenderer.material.color = nextColor;

        // Deactivate the current background
        currentBackgroundRenderer.gameObject.SetActive(false);
    }
}
