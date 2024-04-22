using UnityEngine;
using System.Collections;

public class MoveObject6 : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1.0f;
    public float time = 1.0f;

    private float elapsedTime = 0.0f;
    private Vector3 targetPosition;

    private void Start()
    {
        // Move the object to the first point
        transform.position = pointA.position;
        targetPosition = pointB.position;

        // Reset the elapsed time
        elapsedTime = 0.0f;
    }

    private void Update()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // If the elapsed time is greater than the specified time, switch to the other point
        if (elapsedTime > time)
        {
            // Switch to the other point
            if (targetPosition == pointB.position)
            {
                targetPosition = pointA.position;
            }
            else
            {
                targetPosition = pointB.position;
            }

            // Reset the elapsed time
            elapsedTime = 0.0f;
        }
    }
}