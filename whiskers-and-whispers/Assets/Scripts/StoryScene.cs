using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]

public class StoryScene : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite background;
    public float backgroundOpacity = 1.0f;
    public StoryScene nextScene;

    [System.Serializable]

    public struct Sentence
    {
        public string text;
        public Speaker speaker;
        // public List<Action> actions;
        // [System.Serializable]
        // public struct Action
        // {
        //     public Speaker speaker;
        //     public int spriteIndex;
        //     public Type actionType;

        //     [System.Serializable]
        //     public enum Type
        //     {
        //         NONE, APPEAR, DISAPPEAR
        //     }

        // }
    }
}
