using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public string Name;
    public Sprite portrait;
    public Sprite portraitAngry;
    public Sprite portraitLove;
    public Sprite portraitHappy;
    public Sprite portraitHurt;
}
