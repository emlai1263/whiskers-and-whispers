using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerUI : MonoBehaviour
{
    public Image portrait;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI dialogue;
    public Mood mood;

    private Character speaker;
    public Character Speaker
    {
        get { return speaker; }
        set
        {
            speaker = value;
            portrait.sprite = speaker.portrait;
            Name.text = speaker.Name;
        }
    }

    public string Dialogue
    {
        get { return dialogue.text; }
        set { dialogue.text = value; }
    }

    public Mood Mood
    {
        set
        {
            Sprite sprite;
            if (value == Mood.Happy)
            {
                sprite = speaker.portraitHappy;
            }
            else if (value == Mood.Hurt)
            {
                sprite = speaker.portraitHurt;
            }
            else if (value == Mood.Angry)
            {
                sprite = speaker.portraitAngry;
            }
            else if (value == Mood.Love)
            {
                sprite = speaker.portraitLove;
            }
            else
            {
                sprite = speaker.portrait;
            }
            portrait.sprite = sprite;
        }
    }

    public bool HasSpeaker()
    {
        return speaker != null;
    }

    public bool SpeakerIs(Character character)
    {
        return speaker == character;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
