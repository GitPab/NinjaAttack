using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Check if the user has clicked the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world space
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0.0f;

            // Move the object to the mouse position
            transform.position = mousePosition;
        }
    }
}