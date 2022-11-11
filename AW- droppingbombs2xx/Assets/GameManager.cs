using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private spawner spawner;
    public GameObject title;
    private Vector2 screenbounds;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
    }

    
    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                ResetGame();
            }
        }
       
    }
    private void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<spawner>();
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = playerPrefab;
    } 

   void  ResetGame()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log(title.activeInHierarchy);
            title.SetActive(false);
            spawner.active = true;

        }

        var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");

        foreach (GameObject bombObject in nextBomb)
        {
            if (bombObject.transform.position.y < (screenbounds.y) - 12)
            {
                Destroy(bombObject);
            }
        }
    }

     void ResetGame ()
    {
        
    }

} 

 