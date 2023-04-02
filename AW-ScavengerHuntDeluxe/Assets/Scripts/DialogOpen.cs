using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpen : MonoBehaviour
{

    public string dialog;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    public bool begin = true;
    public bool end = false;
    private string[] collectibles;
    private int clue;

    private AudioSource greeting;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "key", "fish", "birdhouse", "red airhorn", "magic hat" };
        createClue();
    }

    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialog();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        greeting.Play();
        interfaceManager.GetComponent<InterfaceManager>().ShowBox(dialog, clue);
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            dialog = "You found my" + collectibles[clue] + "! Hooray";
            end = true;
        }
        else
        {
            dialog = "No, that's not my" + collectibles[clue] + ".";
        }
    }

    public void coinsScattered()
    {
        begin = false;
    }

    public void searchDialog()
    {
       if (clue == 0)
        {
            dialog = "Hi! Cant miss this movie tonight, find my film?" ;
        }
       if (clue ==1)
        {
            dialog = "Hi! I need my balloons for this party, can you find them?";
        }
       if (clue ==2)
        {
            dialog = "Hi! i need my life saver to go to the beach , help me find it?" ;
        }
       if (clue ==3 )
        {
            dialog = "Hi! i lost my bull's eye can you find it?" ;
        }
       if (clue ==4)
        {
            dialog = "Hi! i lost my friends pipe,can you help me find it?";
        }
        if(clue ==5)
        {
            dialog = "Hi i lost the key to my house, help me find it?";

        }
        if (clue == 6)
        {
            dialog = "Hi! i lost my pet fish, can you find it?";
        }
        if(clue==7)
        {
            dialog = "Hi! i lost my birdhouse, help me find it?";
        }
        if (clue == 8)
        {
            dialog = "Hi! i lost my favorite red airhorn,can you help me find it?";
        }
        if (clue==9)
        {
            dialog = "Hi! i need my hat for my magic show! Can you help me find it?";
        }
       // dialog = "Hi! can you help me find my " + collectibles[clue] + "?";
    }
}
