using UnityEngine;

public class MoveToRandomPoint : MonoBehaviour
{
    public float speed = 1.0f;
    public float height = 5.0f;

    private Vector3 targetPosition;

    private void Start()
    {
        // Generate a random position above the screen
        targetPosition = new Vector3(Random.Range(-5.0f, 5.0f), height, 0.0f);
    }

    private void Update()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object has reached the target position
        if (transform.position == targetPosition)
        {
            // Generate a new random position
            targetPosition = new Vector3(Random.Range(-5.0f, 5.0f), height, 0.0f);
        }
    }
}