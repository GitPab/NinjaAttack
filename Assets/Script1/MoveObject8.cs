using UnityEngine;
using System.Collections;

public class MoveObject8 : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1.0f;

    private Transform currentPoint;
    private Vector3 targetPosition;

    private void Start()
    {
        currentPoint = pointA;
        targetPosition = pointB.position;
    }

    private void Update()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If the object has reached the target position, switch to the other point
        if (transform.position == targetPosition)
        {
            if (currentPoint == pointA)
            {
                currentPoint = pointB;
                targetPosition = pointA.position;
                Debug.Log("Complete");
            }
            else
            {
                currentPoint = pointA;
                targetPosition = pointB.position;
            }
        }
    }
}