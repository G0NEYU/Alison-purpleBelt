using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update 
    public ParticleSystem poof;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            GameObject door = GameObject.Find("door");
            Destroy(door);
            
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
  
}
