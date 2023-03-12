using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{

    public ParticleSystem explosion;
    public GameObject player;

    private void Start()
    {
        explosion.Stop();
    }

    private void FixedUpdate()
    {
        explosion.transform.position = player.transform.position;
    }
    public void GameOver()
    {
        player.SetActive(false);
        Invoke("Reload", 2);
        explosion.Play();
        Debug.Log("play");

    } 
    void Reload()
    {
        SceneManager.LoadScene(0);
    }
}


