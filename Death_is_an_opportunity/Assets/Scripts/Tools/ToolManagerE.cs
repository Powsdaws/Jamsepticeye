using UnityEngine;
using System.Collections.Generic;

public class ToolManagerE : MonoBehaviour
{
    public static ToolManagerE instance;
    public List<Tool> collectedTools = new List<Tool>();
    public List<Tool> allTools = new List<Tool>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        
        //reset isfound on tools
        foreach (Tool tool in allTools)
        {
            tool.isCollected = false;
        }
    }

    public void AddTool(Tool tool)
    {
        if (!collectedTools.Contains(tool))
        {
            collectedTools.Add(tool);
        }
    }

    public bool HasTool(Tool tool)
    {
        return collectedTools.Contains(tool);
    }
}