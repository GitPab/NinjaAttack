using UnityEngine;

public class Bouncing : MonoBehaviour
{
    // Set the force value in the Unity inspector
    [SerializeField] private float forceValue = 0.01f;

    private Rigidbody2D rb;

    private void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Add force to the object when it collides with another object
        rb.AddForce(Vector3.up * forceValue * 200, ForceMode2D.Impulse);
    }

    private void Update()
    {
        // Get the horizontal input value
        float force = Input.GetAxis("Horizontal");

        // If the input value is not zero, set the force value to the input value
        if (force != 0)
        {
            forceValue = force;
        }
    }
}