using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (target.position.y > transform.position.y)
        {
            transform.position = Vector3.up * target.position.y + offset;
        }
    }
}
