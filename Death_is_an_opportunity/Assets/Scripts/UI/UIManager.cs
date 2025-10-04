using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI clueMessageText;
    public float messageDuration = 4f;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void ShowMessage(string message)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessageRoutine(message));
    }

    private System.Collections.IEnumerator ShowMessageRoutine(string message)
    {
        clueMessageText.text = message;
        clueMessageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(messageDuration);

        clueMessageText.gameObject.SetActive(false);
    }
}