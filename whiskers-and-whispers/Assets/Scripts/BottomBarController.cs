using System.Collections;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;
    //private Animator animator;
    private bool isHidden = false;

    private enum State
    {
        PLAYING, COMPLETED
    }

    private void Start()
    {
        // animator = GetComponent<Animator>();
    }

    // public void Hide()
    // {
    //     if (!isHidden)
    //     {
    //         animator.SetTrigger("Hide");
    //         isHidden = true;
    //     }
    // }

    // public void Show()
    // {
    //     animator.SetTrigger("Show");
    //     isHidden = false;
    // }

    public void ClearText()
    {
        barText.text = "";
    }
    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextScentence();
    }
    public void PlayNextScentence()
    {
        // sentenceIndex++;
        // if (state == State.PLAYING)
        // {
        //     // If currently typing, skip to the end
        //     StopCoroutine("TypeText");
        //     barText.text = currentScene.sentences[sentenceIndex].text;
        //     state = State.COMPLETED;
        // }

        // else
        // {
        //     StartCoroutine(TypeText(currentScene.sentences[sentenceIndex].text));
        //     personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        //     personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
        //     barText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
        // }
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
        barText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
    }

    public void SkipTyping()
    {
        StopCoroutine("TypeText");
        barText.text = currentScene.sentences[sentenceIndex].text;
        state = State.COMPLETED;
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentece()
    {
        return sentenceIndex == currentScene.sentences.Count - 1;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.03f);
            if (++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
