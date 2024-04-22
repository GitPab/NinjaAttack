using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private int direct = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * direct * speed * Time.deltaTime;

        if (transform.position.x >= 2f)
        {
            direct = -1;
        }
        else if (transform.position.x <= -2f)
        {
            direct = 1;
        }
    }
}
