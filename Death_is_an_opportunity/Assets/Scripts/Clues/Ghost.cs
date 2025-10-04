using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header("Ghost Info")]
    public string ghostName;
    [TextArea] public string dialogueBefore; // says this when player enters room
    [TextArea] public string dialogueAfter;  // says this when all clues found
    public Clue[] requiredClues;
    
    public AudioSource mumbleSource;
    public AudioClip[] ghostClip;
    public Tool requiredTool;

    private bool hasAppeared = false;
    private bool hasSpokenBefore = false;

    private void Start()
    {
        // Optional: make ghost semi-transparent at start
        SetGhostVisible(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // When player enters the room and ghost hasn't appeared yet
            if (!hasAppeared && !hasSpokenBefore)
            {
                hasSpokenBefore = true;
                Speak(dialogueBefore, ".*-.-.(unknown ghost):");
            }
        }
    }

    public void CheckClues()
    {
        // Check if all required clues are found
        foreach (Clue clue in requiredClues)
        {
            if (!clue.isFound)
                return; // not all clues yet
        }

        // All clues found, reveal ghost
        if (!hasAppeared)
        {
            hasAppeared = true;
            if (mumbleSource != null) mumbleSource.PlayOneShot(ghostClip[Random.Range(0, ghostClip.Length)]);
            SetGhostVisible(true);
            Speak(dialogueAfter, ghostName);
        }
    }

    private void Speak(string message, string ghost_name)
    {
        Debug.Log($".*-.-.(unknown ghost): {message}");
        UIManager.instance.ShowMessage($"{ghost_name}: {message}");
    }

    private void SetGhostVisible(bool visible)
    {
        // Toggles renderer visibility
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = visible;
        }
    }

    public void OnObjectFixed()
    {
        GhostManager.instance.GhostFound();
        SetGhostVisible(false);
    }
}
