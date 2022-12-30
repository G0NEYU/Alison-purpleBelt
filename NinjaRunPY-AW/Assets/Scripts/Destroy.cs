using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update 
     
     void OnnTriggerEnter(Collider other )
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
