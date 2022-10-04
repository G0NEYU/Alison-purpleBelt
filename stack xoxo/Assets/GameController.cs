using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Cube Object")]
    public GameObject currentCube;
   [Header("Last Cube Object")]
    public GameObject lastCube;
    [Header("Text object")]
    public Text text;
    [Header("Current Level")]
    public int Level;

    [Header("Boolean")]
    public bool Done;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    void Newblock()
    {
        if(lastCube != null)
        {
            currentCube.transform.position = new Vector3(Mathf.Round(currentCube.transform.position.x),
                currentCube.transform.position.y,
                Mathf.Round(currentCube.transform.position.z));
        }
    }
}
