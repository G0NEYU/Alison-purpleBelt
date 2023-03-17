using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{

    public ParticleSystem explosion;
    public GameObject player;
    public GameObject GameOverScreen;

    private void Start()
    {
        explosion.Stop();
     //   GameOverScreen.SetActive(false);
    }

    private void FixedUpdate()
    {
        explosion.transform.position = player.transform.position;
       // GameObject.Find("GameOverScreen");
    }
    public void GameOver()
    {
        //GameOverScreen.GetComponent<LevelReset>().GameOver();
        player.SetActive(false);
        Invoke("Reload", 1);
        explosion.Play();
        Debug.Log("play");

    } 
    void Reload()
    {
        SceneManager.LoadScene(1);
      


    }
}


