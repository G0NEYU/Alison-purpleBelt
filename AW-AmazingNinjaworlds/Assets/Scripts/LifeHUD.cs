using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHUD : MonoBehaviour
{
    public GameObject[] heart;
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
        Debug.Log("Ouch!");
        lives -= 1;
        heart[lives].SetActive(false);
        if (lives == 0)
        {
            background.GetComponent<GameManager>().GameOver();
            heart[lives].SetActive(false);
        }
    }
    public void HealPlayer()
    {
        Debug.Log("Yay!");
        if(lives < 3)
        {
            heart[lives].SetActive(true);
            lives += 1;
        } 
    }
}
