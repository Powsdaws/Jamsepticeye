using UnityEngine;

public class FixableObject : MonoBehaviour
{
    public Tool requiredTool;
    public bool isFixed = false;
    public Ghost associatedGhost;

    private void OnMouseDown()
    {
        if (isFixed) return;

        if (ToolManagerE.instance.HasTool(requiredTool))
        {
            isFixed = true;
            UIManager.instance.ShowMessage("You fixed the leak!");
            // Optional: Play particle effect, stop water sound, etc.
            if (associatedGhost != null)
            {
                associatedGhost.OnObjectFixed();
            }
            
            Destroy(gameObject);
        }
        else
        {
            UIManager.instance.ShowMessage($"You need a {requiredTool.toolName} to fix this!");
        }
    }
}