using UnityEngine;

namespace Tools
{
    public class ToolPickup : MonoBehaviour
    {
        public Tool toolData;
    
        private Vector3 originalPosition;
        private bool isHovered = false;
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
    
        //THIS IS CALLED BY PLAYER PICK
        public void OnClick()
        {
            if (!toolData.isCollected)
            {
                toolData.isCollected = true;
                UIManager.instance.ShowMessage($"You picked up the {toolData.toolName}!");
                Debug.Log("Found clue: " + toolData.toolName);
                ToolManagerE.instance.AddTool(toolData);
                Destroy(gameObject); // remove after pickup
            }
        }
        
        public void Hover(bool active)
        {
            isHovered = active;
        }
    
    }
}