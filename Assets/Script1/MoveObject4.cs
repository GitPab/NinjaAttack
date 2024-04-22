using UnityEngine;
using System.Collections;

public class MoveObject4 : MonoBehaviour
{
    public Transform[] points;
    public float speed = 1.0f;

    private void Start()
    {
        // Move the object to the first point
        transform.position = points[0].position;

        // Start a coroutine to move the object to the other points
        StartCoroutine(MoveToPoints());
    }

    private IEnumerator MoveToPoints()
    {
        // Move the object to each point
        for (int i = 1; i < points.Length; i++)
        {
            // Move the object to the next point
            Vector3 targetPosition = points[i].position;
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            // Wait for a random time before moving to the next point
            float waitTime = Random.Range(1.0f, 2.0f);
            yield return new WaitForSeconds(waitTime);
        }

        // Move the object back to the first point
        while (transform.position != points[0].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);
            yield return null;
        }
    }
}