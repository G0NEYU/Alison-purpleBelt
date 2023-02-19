using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
   
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sphere")) {
            GameObject Wall =  GameObject.FindGameObjectWithTag("Wall");
            GameObject Sphere = GameObject.FindGameObjectWithTag("sphere");
          
            Destroy(Wall.gameObject);
            Destroy(Sphere.gameObject);
        }
    }
}
