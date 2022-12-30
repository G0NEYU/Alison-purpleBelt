using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update 

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
  
}
