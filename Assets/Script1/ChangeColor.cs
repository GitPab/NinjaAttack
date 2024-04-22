using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
    private Material originalMaterial;
    private Material newMaterial;

    private void Start()
    {
        // Save the original material
        originalMaterial = GetComponent<Renderer>().material;

        // Create a new material
        newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.color = Color.red;
    }

    private void OnMouseDown()
    {
        // Switch between the original and new material
        if (GetComponent<Renderer>().material == originalMaterial)
        {
            GetComponent<Renderer>().material = newMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}