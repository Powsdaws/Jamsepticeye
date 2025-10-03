using UnityEngine;

public class GhostFloat : MonoBehaviour
{
    [Header("Floating Settings")]
    public float floatHeight = 0.5f;   // how far up and down it moves
    public float floatSpeed = 2f;      // how fast it bobs

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}