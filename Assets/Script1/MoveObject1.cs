using UnityEngine;

public class MoveObject1 : MonoBehaviour
{
    public Transform[] points;
    public float speed = 1.0f;

    private int currentPointIndex = 0;
    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = points[currentPointIndex].position;
    }

    private void Update()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If the object has reached the target position, set the new target position
        if (transform.position == targetPosition)
        {
            currentPointIndex++;

            if (currentPointIndex >= points.Length)
            {
                currentPointIndex = 0;
            }

            targetPosition = points[currentPointIndex].position;
        }
    }
}