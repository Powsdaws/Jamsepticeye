using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Called by Start Button
    public void PlayGame()
    {
        // Loads the next scene in Build Settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Called by Quit Button
    public void QuitGame()
    {
        Debug.Log("Quit Game!"); // Works in Editor
        Application.Quit();      // Works in Build
    }
}