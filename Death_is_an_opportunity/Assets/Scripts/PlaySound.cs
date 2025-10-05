using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Collider))]
public class PlaySound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasPlayed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Make sure the collider is a trigger
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) return;

        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            hasPlayed = true;
            Destroy(gameObject, audioSource.clip.length);
        }

    }
}