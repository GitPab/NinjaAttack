using UnityEngine;

public class SoundKey : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C");
        }
    }
}