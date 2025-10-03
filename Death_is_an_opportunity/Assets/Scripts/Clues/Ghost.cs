using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header("Ghost Info")]
    public string ghostName;
    [TextArea] public string dialogueBefore; // What ghost says if clues are missing
    [TextArea] public string dialogueAfter;  // What ghost says once all clues are found
    public Clue[] requiredClues;

    private bool hasAppeared = false;

    private void Start()
    {
        // Hide ghost until clues are ready
        hasAppeared = false;
        gameObject.SetActive(false); // Ghost always hidden at the start
    }

    public void CheckClues()
    {
        foreach (Clue clue in requiredClues)
        {
            if (!clue.isFound) return; // Some clues not found yet
        }

        if (!hasAppeared)
        {
            gameObject.SetActive(true); // Ghost appears
            hasAppeared = true;
            TalkToGhost();

            // UI message
            UIManager.instance.ShowMessage($"{ghostName} has appeared!");
        }
    }

    public void TalkToGhost()
    {
        foreach (Clue clue in requiredClues)
        {
            if (!clue.isFound)
            {
                Debug.Log(dialogueBefore);
                UIManager.instance.ShowMessage(dialogueBefore);
                return;
            }
        }

        Debug.Log(dialogueAfter);
        UIManager.instance.ShowMessage(dialogueAfter);
    }
}