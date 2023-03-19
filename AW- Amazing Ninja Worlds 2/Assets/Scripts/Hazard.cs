using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hazard : MonoBehaviour
{       
    // references to the background and the healthbar
    public GameObject background;
    public GameObject HealthBar;

    // when the player collides with a hazard
    private void OnTriggerEnter(Collider other)
    {
        // ask the background's game manager script to move the player to the checkpoint
        background.GetComponent<GameManager>().moveToCheckPoint();
     
      //  background.GetComponent<GameManager>().UpdateCheckPoint( new Vector3(0 , 0, 0));
        // ask the healthbar to hurt the player
        HealthBar.GetComponent<LifeHUD>().HurtPlayer();
    }
}
