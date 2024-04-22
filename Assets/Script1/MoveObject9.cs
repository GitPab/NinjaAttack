using UnityEngine;

public class MoveObject9 : MonoBehaviour
{
    public float speed = 1.0f;

    private void Update()
    {
        // Get the horizontal input axis
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Calculate the movement direction
        Vector3 movementDirection = new Vector3(moveHorizontal, 0.0f, 0.0f);

        // Move the object in the movement direction
        transform.position += movementDirection * speed * Time.deltaTime;
    }
}