using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public ParticleSystem poof;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {  
            score++;
            scoreText.text = score.ToString();
            Destroy(other.gameObject);
            Debug.Log("Score: " + score);
            poof.Play();

        }

    }


        void Start()
        {
        poof.Stop();
        score = 0;
        }

        void Update()
        {

        }
    }
