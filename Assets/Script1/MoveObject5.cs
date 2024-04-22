using UnityEngine;
using System.Collections;

public class MoveObject5 : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1.0f;

    private void Start()
    {
        // Move the object to the first point
        transform.position = pointA.position;

        // Start a coroutine to move the object between the points
        StartCoroutine(MoveBetweenPoints());
    }

    private IEnumerator MoveBetweenPoints()
    {
        // Move the object to the second point
        while (transform.position != pointB.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            yield return null;
        }

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Move the object back to the first point
        while (transform.position != pointA.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            yield return null;
        }

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Move the object back to the second point
        while (transform.position != pointB.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            yield return null;
        }

        // Repeat the process
        StartCoroutine(MoveBetweenPoints());
    }
}