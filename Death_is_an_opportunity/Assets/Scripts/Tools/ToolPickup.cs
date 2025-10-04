using UnityEngine;

public class ToolPickup : MonoBehaviour
{
    public Tool toolData;

    private void OnMouseDown()
    {
        if (!toolData.isCollected)
        {
            toolData.isCollected = true;
            UIManager.instance.ShowMessage($"You picked up the {toolData.toolName}!");
            ToolManagerE.instance.AddTool(toolData);
            Destroy(gameObject);
        }
    }
}