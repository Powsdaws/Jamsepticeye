using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    public Camera playerCamera; 
    public float interactRange = 5f;

    private CluePickup hoveredClue = null;

    void Update()
    {
        // --- Hover detection ---
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            CluePickup clue = hit.collider.GetComponent<CluePickup>();
            if (clue != null)
            {
                if (hoveredClue != clue)
                {
                    ClearHighlight();
                    hoveredClue = clue;
                    hoveredClue.Highlight(true);
                }
            }
            else
            {
                ClearHighlight();
            }
        }
        else
        {
            ClearHighlight();
        }

        // --- Click detection ---
        if (Input.GetMouseButtonDown(0) && hoveredClue != null)
        {
            hoveredClue.OnClick();
        }
    }

    void ClearHighlight()
    {
        if (hoveredClue != null)
        {
            hoveredClue.Highlight(false);
            hoveredClue = null;
        }
    }
}