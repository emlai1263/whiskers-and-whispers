using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
    public Conversation conversation;
    public GameObject speaker1;
    public GameObject speaker2;
    public GameObject speaker3;
    private SpeakerUI speakerUI1;
    private SpeakerUI speakerUI2;
    private SpeakerUI speakerUI3;

    private int activeLineIndex = 0;

    private void Start()
    {
        speakerUI1 = speaker1.GetComponent<SpeakerUI>();
        speakerUI2 = speaker2.GetComponent<SpeakerUI>();
        speakerUI3 = speaker3.GetComponent<SpeakerUI>();
        speakerUI1.Speaker = conversation.speaker1;
        speakerUI2.Speaker = conversation.speaker2;
        speakerUI3.Speaker = conversation.speaker3;
        AdvanceConversation();
    }


    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AdvanceConversation();
        }
    }

    void AdvanceConversation()
    {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speakerUI1.Hide();
            speakerUI2.Hide();
            speakerUI3.Hide();
            activeLineIndex = 0;
            gameObject.SetActive(false);
        }
    }

    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUI1.SpeakerIs(character))
        {
            SetDialogue(speakerUI1, speakerUI2, speakerUI3, line.text);
            speakerUI1.Mood = line.mood;

        }
        else if (speakerUI2.SpeakerIs(character))
        {

            SetDialogue(speakerUI2, speakerUI1, speakerUI3, line.text);
            speakerUI2.Mood = line.mood;

        }
        else
        {

            SetDialogue(speakerUI3, speakerUI1, speakerUI2, line.text);
            speakerUI3.Mood = line.mood;
        }
    }

    void SetDialogue(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI1, SpeakerUI inactiveSpeakerUI2, string text)
    {
        activeSpeakerUI.Dialogue = text;
        inactiveSpeakerUI1.Hide();
        inactiveSpeakerUI2.Hide();
        activeSpeakerUI.Show();
    }
}
