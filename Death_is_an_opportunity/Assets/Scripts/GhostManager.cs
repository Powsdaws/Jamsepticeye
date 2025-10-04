using UnityEngine;
using TMPro;

public class GhostManager : MonoBehaviour
{
    public static GhostManager instance;

    public int totalGhosts;          // Total ghosts in the scene
    private int foundGhosts = 0;     // Ghosts player has found

    [Header("UI")]
    public TextMeshProUGUI ghostCounterText; // Assign in Inspector

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        UpdateGhostUI();
    }

    public void GhostFound()
    {
        foundGhosts++;
        UpdateGhostUI();

        if (foundGhosts >= totalGhosts)
        {
            GameCompleted();
        }
    }

    private void UpdateGhostUI()
    {
        if (ghostCounterText != null)
            ghostCounterText.text = $"Issues resolved: {foundGhosts}/{totalGhosts}";
    }

    private void GameCompleted()
    {
        Debug.Log("All ghosts found! Game Completed!");
        UIManager.instance.ShowMessage("All ghosts found! You win!");
        // Optional: trigger scene change or victory UI
    }
}