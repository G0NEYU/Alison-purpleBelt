using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{
    public bool hit;
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        int layerMask = 1 << 8;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2f , layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Careful ahead");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Clear ");

        }

    }
}
