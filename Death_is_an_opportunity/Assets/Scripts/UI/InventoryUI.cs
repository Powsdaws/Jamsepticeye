using TMPro;
using UnityEngine;

namespace UI
{
    public class InventoryUI : MonoBehaviour
    {
        public static InventoryUI instance;
        public Transform clueContentParent; // Content object inside ScrollView for clues
        public GameObject clueItemPrefab;   // Prefab with TextMeshProUGUI

        //public Transform toolContentParent; // Content object inside ScrollView for tools
        //public GameObject toolItemPrefab;

        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);
        }

        
        
        public void RefreshClues()
        {
            foreach (Transform t in clueContentParent) Destroy(t.gameObject);

            foreach (Clue clue in ClueManager.instance.foundClues)
            {
                Debug.Log("Adding clue: " + clue.clueName);
                GameObject item = Instantiate(clueItemPrefab, clueContentParent);
                TextMeshProUGUI text = item.GetComponentInChildren<TextMeshProUGUI>();
            
                if (text == null) Debug.LogError("TextMeshProUGUI not found in prefab!");

                // Find the ghost associated with this clue
                string ghostName = "Unknown";
                foreach (Ghost ghost in FindObjectsOfType<Ghost>())
                {
                    if (System.Array.Exists(ghost.requiredClues, c => c == clue))
                    {
                        ghostName = ghost.ghostName;
                        break;
                    }
                }

                text.text = $"{clue.clueName} (Ghost: {ghostName})";
            }
        }

        /*
        public void RefreshTools()
        {
            foreach (Transform t in toolContentParent) Destroy(t.gameObject);

            foreach (Tool tool in ToolManagerE.instance.collectedTools)
            {
                GameObject item = Instantiate(toolItemPrefab, toolContentParent);
                TextMeshProUGUI text = item.GetComponentInChildren<TextMeshProUGUI>();
                text.text = tool.toolName;
            }
        }
        */
    }
}