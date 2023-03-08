using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    private GameObject[] heart;
    private int lives = 3;
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        heart = GameObject.FindGameObjectsWithTag("heart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtPlayer()
    {

    }
}
