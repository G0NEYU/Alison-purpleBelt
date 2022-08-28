using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Platform Object")]
    public GameObject platform;
    float pos = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; 1 < 1000; i++)
        {

            SpawnPlatforms();

        }



    }

    void SpawnPlatforms()
    {
        Instantiate(platform, new Vector3(Random.value * 10 - 5f, pos,  0.5f), Quaternion.identity);
        pos += 2.5f;
    }






}
