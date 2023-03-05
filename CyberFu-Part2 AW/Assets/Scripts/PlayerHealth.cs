using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int currentPlayerHealth = 30;
    public int enemyDamage = 4;

    public PlayerExplosionParticles particles;

    private Animator playerAnimator;
    public Text healthText;
    PlayerHealth playerHealth;



    void Start()
    { 
        
        playerAnimator = GetComponent<Animator>();
        particles = GetComponent<PlayerExplosionParticles>();
        GameObject BluePlayer = GameObject.Find("BluePlayer");
        playerHealth = BluePlayer.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (playerHealth || true)
        {
          
            //Debug.Log(playerHealth.currentPlayerHealth);
            healthText.text = playerHealth.currentPlayerHealth.ToString();
        }
    }

    public void HurtPlayer()
    {
        
        enemyDamage = Random.Range(3, 11);
        currentPlayerHealth -= enemyDamage;

        if (currentPlayerHealth <= 0 )
        {
            gameObject.SetActive(false);
        } 

        if (currentPlayerHealth <= 0)
        {
            // gameObject.SetActive(false);
            particles.Explode();
            Invoke("ReloadScene", 5);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HitCollider")
        {
            HurtPlayer();
            playerAnimator.SetTrigger("Hit");
        }
    }  
    private void ReloadScene()
    {
        SceneManager.LoadScene("CyberFu");
    }
}
