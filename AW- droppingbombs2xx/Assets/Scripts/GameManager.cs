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

    private bool smokeCleared = true;

    private int bestScore = 0;
    public Text bestScoreText;
    private bool beatBestScore;
    // Start is called before the first frame update

  
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);

        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best Score :" + bestScore.ToString();
    }

    
    // Update is called once per frame
    void Update()
    {



        if (Input.anyKeyDown && smokeCleared && !gameStarted)
        {
            smokeCleared = false;
            ResetGame();
        }
        else
        {
            if (!player)
            {
                OnPlayerKilled();
            }
        }
        var nextBomb = GameObject.FindGameObjectsWithTag("bomb");
        foreach (GameObject bombObject in nextBomb)
        {
            if (bombObject.transform.position.y < (-screenBounds.y) - 12 || !gameStarted)
            {
                scoreSystem.GetComponent<Score>().AddScore(pointsWorth);
                Destroy(bombObject);
                Debug.Log("add score");
            }
        }
        if (!gameStarted)
        {
            var textColor = "323232";
            if (beatBestScore)
            {
                textColor = "#F00";
            }

            bestScoreText.text = "<color=" + textColor + ">Best Score: " + bestScore.ToString() + "</color>";

        }
        else
        {
            bestScoreText.text = "";


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

            beatBestScore = false;
            bestScoreText.enabled = true;

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
        Invoke("SplashScreen", 2f);
        // Debug.Log("killed"); 
        score = scoreSystem.GetComponent<Score>().score;
        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            beatBestScore = true;
            bestScoreText.text = "Best Score:" + bestScore.ToString();

        }
    }
    void SplashScreen ()
    {
        smokeCleared = true;
        splash.SetActive(true);
    }
} 

 