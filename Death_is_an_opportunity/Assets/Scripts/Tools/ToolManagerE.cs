using UnityEngine;
using System.Collections.Generic;

public class ToolManagerE : MonoBehaviour
{
    public static ToolManagerE instance;
    public List<Tool> collectedTools = new List<Tool>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
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