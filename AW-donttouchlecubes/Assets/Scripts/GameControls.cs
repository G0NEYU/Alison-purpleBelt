using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour
{
    private Text timerText;
    private int timerCount;

    // Start is called before the first frame update

    // Update is called once per frame
    IEnumerator CountTime ()
    {
        yield return new WaitForSeconds(1f);
        timerCount++;
        timerText.text = "Score: " + timerCount;
        StartCoroutine(CountTime());
    }

     void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(CountTime());
        timerText = GameObject.Find("Score").GetComponent<Text>();
    }
     void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(0);
    }
}