using Tools;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public Camera playerCamera; 
    public float interactRange = 5f;

    private CluePickup hoveredClue = null;
    private ToolPickup hoveredTool = null;

    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            CluePickup clue = hit.collider.GetComponent<CluePickup>();
            ToolPickup tool = hit.collider.GetComponent<ToolPickup>();

            if (clue != null)
            {
                if (hoveredClue != clue)
                {
                    ClearHover();
                    hoveredClue = clue;
                    hoveredClue.Hover(true);
                }
            }
            else if (tool != null)
            {
                if (hoveredTool != tool)
                {
                    ClearHover();
                    hoveredTool = tool;
                    hoveredTool.Hover(true);
                }
            }
            else
            {
                ClearHover();
            }
        }
        else
        {
            ClearHover();
        }

        // --- Click detection ---
        if (Input.GetMouseButtonDown(0))
        {
            if (hoveredClue != null)
            {
                hoveredClue.OnClick();
            }
            else if (hoveredTool != null)
            {
                hoveredTool.OnClick();
            }
        }
    }

    void ClearHover()
    {
        if (hoveredClue != null)
        {
            hoveredClue.Hover(false);
            hoveredClue = null;
        }

        if (hoveredTool != null)
        {
            hoveredTool.Hover(false);
            hoveredTool = null;
        }
    }
}