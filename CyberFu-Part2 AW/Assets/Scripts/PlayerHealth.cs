using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentPlayerHealth = 10;
    public int enemyDamage = 2;

    public PlayerExplosionParticles particles;

    private Animator playerAnimator;
   
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        particles = GetComponent<PlayerExplosionParticles>();
    }
     
    public void HurtPlayer()
    {
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
