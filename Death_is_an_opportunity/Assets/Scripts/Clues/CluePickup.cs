using UI;
using UnityEngine;

public class CluePickup : MonoBehaviour
{
    public Clue clueData;

    private Vector3 originalPosition;
    public bool isHovered = false;
    public float hoverHeight = 0.2f;     // how much it moves up
    public float hoverSpeed = 5f;        // how fast it moves

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Smoothly move up if hovered, back down if not
        Vector3 targetPos = isHovered ? originalPosition + Vector3.up * hoverHeight : originalPosition;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * hoverSpeed);
    }

    public void OnClick()
    {
        if (!clueData.isFound)
        {
            clueData.isFound = true;
            Debug.Log("Found clue: " + clueData.clueName);
            ClueManager.instance.AddClue(clueData);
            InventoryUI.instance.RefreshClues();
            //Destroy(gameObject); // remove after pickup
        }
    }

    public void Hover(bool active)
    {
        isHovered = active;
    }
}