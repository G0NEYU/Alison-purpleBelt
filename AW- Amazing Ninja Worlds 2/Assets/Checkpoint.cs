using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject background;


    private void OnTriggerEnter(Collider other)
    {
        Vector3 newCheckpoint = transform.position;
        background.GetComponent<GameManager>().checkPoint = newCheckpoint;
    }
}
