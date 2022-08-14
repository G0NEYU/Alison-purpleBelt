using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Default Speed")]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
