using UnityEngine;

[CreateAssetMenu(fileName = "NewTool", menuName = "Game/Tool")]
public class Tool : ScriptableObject
{
    public string toolName;
    [TextArea] public string description;
    public Sprite icon;
    public bool isCollected = false;
}