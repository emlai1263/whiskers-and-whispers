using UnityEngine;
using UnityEngine.UI;

public enum Mood
{
    Happy,
    Angry,
    Hurt,
    Love,
    Neutral
}

[System.Serializable]
public struct Line
{
    public Character character;

    [TextArea(2, 5)]
    public string text;
    public Mood mood;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public Character speaker1;
    public Character speaker2;
    public Character speaker3;
    public Line[] lines;
}
