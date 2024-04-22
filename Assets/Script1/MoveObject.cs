using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1.0f;

    private Transform currentPoint;
    private Vector3 targetPosition;

    private void Start()
    {
        currentPoint = pointA;
        targetPosition = currentPoint.position;
    }

    private void Update()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If the object has reached the target position, set the new target position
        if (transform.position == targetPosition)
        {
            if (currentPoint == pointA)
            {
                currentPoint = pointB;
            }
            else
            {
                currentPoint = pointA;
            }

            targetPosition = currentPoint.position;
        }
    }
}