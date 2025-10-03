using UnityEngine;

//We attach this script to objects that are clues!
//The object needs a collider (set to is trigger)
//Drag the Clue into cluedata (Clues are assets) 
public class CluePickup : MonoBehaviour
{
    public Clue clueData;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !clueData.isFound)
        {
            clueData.isFound = true;
            Debug.Log("Found clue: " + clueData.clueName);

            // You can update UI here
            ClueManager.instance.AddClue(clueData);

            Destroy(gameObject); // Remove clue object from scene
        }
    }
}
