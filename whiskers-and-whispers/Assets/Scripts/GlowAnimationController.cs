using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlowAnimationController : MonoBehaviour
{
    public Transform player;
    public Transform[] sprites; // Array of sprites
    public float activationDistance = 5f;
    public float minAlpha = 0.5f;
    public float maxAlpha = 1f;
    public float alphaChangeSpeed = 1f;
    private SpriteRenderer[] spriteRenderers;
    private Image[] images;
    private Button[] buttons;
    private bool[] isPlayerNear;

    void Start()
    {
        spriteRenderers = new SpriteRenderer[sprites.Length];
        images = new Image[sprites.Length];
        buttons = new Button[sprites.Length];
        isPlayerNear = new bool[sprites.Length];

        // Get the Animator components for each sprite
        for (int i = 0; i < sprites.Length; i++)
        {
            spriteRenderers[i] = sprites[i].GetComponent<SpriteRenderer>();
            images[i] = sprites[i].GetComponent<Image>();
            isPlayerNear[i] = false;
            buttons[i] = sprites[i].GetComponent<Button>();
            buttons[i].interactable = false; // Initially not interactable
            Color currentColor = images[i].color;
            currentColor.a = 1f;
        }
    }

    void Update()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            float distance = Vector3.Distance(player.position, sprites[i].position);
            if (distance <= activationDistance)
            {
                if (!isPlayerNear[i])
                {
                    isPlayerNear[i] = true;
                    buttons[i].interactable = true; // Make button interactable
                    ToggleSpriteRenderer(spriteRenderers[i], false);
                }
                float targetAlpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time * alphaChangeSpeed, 1f));
                ChangeAlpha(images[i], targetAlpha);
            }
            else
            {
                if (isPlayerNear[i])
                {
                    isPlayerNear[i] = false;
                    buttons[i].interactable = false;
                    ToggleSpriteRenderer(spriteRenderers[i], true);
                }
                ChangeAlpha(images[i], maxAlpha);
            }
        }
    }
    void ChangeAlpha(Image image, float targetAlpha)
    {
        Color currentColor = image.color;
        currentColor.a = targetAlpha;
        image.color = currentColor;
    }

    void ToggleSpriteRenderer(SpriteRenderer spriteRenderer, bool isVisible)
    {
        spriteRenderer.enabled = isVisible;
    }
}
