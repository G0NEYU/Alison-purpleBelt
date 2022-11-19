using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private spawner spawner;
    public GameObject title;
    private Vector2 screenBounds;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;
    public GameObject splash;
    public GameObject scoreSystem;
    public Text scoreText;
    public int pointsWorth = 1;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);
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
        } else
        {
            if (!player)
            {
                OnPlayerKilled();
            }
        }

        var nextBomb = GameObject.FindGameObjectsWithTag("bomb");
        foreach (GameObject bombObject in nextBomb)
        {
            if (bombObject.transform.position.y < (-screenBounds.y) -12 || !gameStarted) 
                //if the bombs y is to about -12 it would destroy the bomb object and add a point to the score
            {
                scoreSystem.GetComponent<Score>().AddScore(pointsWorth);
                Destroy(bombObject);
                Debug.Log("add score");
            }
        }

    }
    private void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        player = playerPrefab;
        scoreText.enabled = false;

    } 

   void  ResetGame()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log(title.activeInHierarchy);
            title.SetActive(false);
            spawner.active = true;
            splash.SetActive(false);
            player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
            gameStarted = true;

            scoreText.enabled = true;
            scoreSystem.GetComponent<Score>().score = 0;
            scoreSystem.GetComponent<Score>().Start();

        }

        //var nextBomb = GameObject.FindGameObjectsWithTag("bomb");

        //foreach (GameObject bombObject in nextBomb)
        //    if (!gameStarted)
        //    {
        //        Destroy(bombObject);
        //    } else if (bombObject.transform.position.y < (-screenBounds.y) && gameStarted)
        //{
        //        scoreSystem.GetComponent<Score>().AddScore(pointsWorth);
        //        Debug.Log("add score");
        //        Destroy(bombObject);
        //    //if (bombObject.transform.position.y < (screenbounds.y) - 12)
        //    //{
        //    //    Destroy(bombObject);
        //    //}
        //}
    }

   

    void OnPlayerKilled()
    {
        spawner.active = false;
        gameStarted = false;
        splash.SetActive(true);
    }

} 

 