using System.Collections.Generic;
using UnityEngine;

//is a singleton and should only exist on a single object
public class ClueManager : MonoBehaviour
{
    public static ClueManager instance;
    public List<Clue> foundClues = new List<Clue>();
    public List<Clue> allClues; // drag all clue assets here

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        
        //reset isfound on clues
        foreach (Clue clue in allClues)
        {
            clue.isFound = false;
        }
        
        foreach (var clue in foundClues)
        {
            Debug.Log($"{clue.name} has been found!");
        }
    }

    //When a clue is found, we add it and check if a ghost have all the clues it needs!
    public void AddClue(Clue clue)
    {
        if (!foundClues.Contains(clue))
        {
            foundClues.Add(clue);
            Debug.Log("Clues found: " + foundClues.Count);

            // Tell all ghosts to check if they're ready
            Ghost[] ghosts = FindObjectsOfType<Ghost>(true); // include inactive
            foreach (Ghost g in ghosts) g.CheckClues();
        }
    }

    public bool HasClue(string clueName)
    {
        return foundClues.Exists(c => c.clueName == clueName);
    }

    public int TotalCluesFound()
    {
        return foundClues.Count;
    }
}