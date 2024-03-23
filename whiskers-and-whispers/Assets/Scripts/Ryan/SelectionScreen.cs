using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this line for SceneManager

public class SelectionScreen : MonoBehaviour
{
    public List<StoryScene> scenes;
    public BottomBarController bottomBar;
    public List<SpriteRenderer> backgroundRenderers;
    public GameObject MiffyButton;
    public GameObject GusButton;
    public GameObject KiwieButton;
    public GameObject RyanButton;
    public GameObject DugButton;
    public GameObject JunkatButton;
    public float fadeDuration = 1.0f;
    private int currentSceneIndex = 0;
    private State state = State.IDLE;
    private enum State
    {
        IDLE, ANIMATE
    }

    void Start()
    {
        bottomBar.PlayScene(scenes[currentSceneIndex]);
        //backgroundController.SetImage(currentScene.background);
        SetBackground(scenes[currentSceneIndex].background); // Set initial background
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (state == State.IDLE)
            {
                if (!bottomBar.IsCompleted())
                {
                    bottomBar.SkipTyping();
                }
                else
                {
                    if (bottomBar.IsLastSentece())
                    {
                        if (currentSceneIndex == scenes.Count - 1) // Check if it's the last scene
                        {
                            //
                        }
                        else
                        {
                            StartCoroutine(SwitchScene(scenes[currentSceneIndex].nextScene));
                        }

                    }
                    else
                    {
                        bottomBar.PlayNextScentence();
                    }
                }
            }
        }
    }

    // private void PlayScene(StoryScene scene)
    // {
    //     StartCoroutine(SwitchScene(scene));
    // }

    private IEnumerator SwitchScene(StoryScene scene)
    {
        // if (scene == null)
        // {
        //     // Load the "Overworld" scene
        //     SceneManager.LoadScene("Overworld");
        // }
        state = State.ANIMATE;
        // Fade out current background
        yield return StartCoroutine(FadeBackground(0.0f));
        currentSceneIndex = scenes.IndexOf(scene);
        bottomBar.PlayScene(scene);
        SetBackground(scene.background);
        // Fade in new background
        yield return StartCoroutine(FadeBackground(1.0f));
        state = State.IDLE;


    }

    private IEnumerator FadeBackground(float targetOpacity)
    {
        foreach (SpriteRenderer backgroundRenderer in backgroundRenderers)
        {
            Color color = backgroundRenderer.color;
            float startOpacity = color.a;
            float timer = 0.0f;

            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                float progress = timer / fadeDuration;
                color.a = Mathf.Lerp(startOpacity, targetOpacity, progress);
                backgroundRenderer.color = color;
                yield return null;
            }

            color.a = targetOpacity;
            backgroundRenderer.color = color;
        }
    }

    private void SetBackground(Sprite sprite)
    {
        foreach (SpriteRenderer backgroundRenderer in backgroundRenderers)
        {
            backgroundRenderer.sprite = sprite;
        }
    }
}