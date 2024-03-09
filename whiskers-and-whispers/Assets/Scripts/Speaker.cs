using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewSpeaker", menuName = "Data/New Speaker")]
[System.Serializable]
public class Speaker : ScriptableObject
{
   public string speakerName;
   public Color textColor;
   // public List<Sprite> sprites;

   // public SpriteController prefab;
}
