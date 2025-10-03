using UnityEngine;

[CreateAssetMenu(fileName = "NewClue", menuName = "Game/Clue")]
public class Clue : ScriptableObject
{
    public string clueName;
    [TextArea] public string description;
    public Sprite clueIcon; // Optional UI icon
    public bool isFound = false;
}