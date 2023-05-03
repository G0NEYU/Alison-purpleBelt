using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public enum LevelType
    {
        TIMER,
        OBSTACLE,
        MOVES,
    };

    public GameGrid grid;
    public HUD hud;

    public Text targetText;
   

    public int score1Star;
    public int score2Star;
    public int score3Star;

   

    protected LevelType type;

    public LevelType Type
    {
        get { return type; }
    }

    public int currentScore;

    protected bool didWin;

    // Start is called before the first frame update
    private void Start()
    {
        type = LevelType.MOVES;

       




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void GameWin()
    {
        didWin = true;
        grid.GameOver();
        StartCoroutine(WaitForGridFill());
    }

    public virtual void GameLose()
    {
        didWin = false;
        grid.GameOver();
        StartCoroutine(WaitForGridFill());
    }

    public virtual void OnMove()
    {
    }






    public virtual void OnPieceCleared(GamePiece piece)
    {
        //Update Score
        currentScore += piece.score;
        

        hud.SetScore (currentScore);


    }

    protected virtual IEnumerator WaitForGridFill()
    {
        while (grid.IsFilling)
        {
            yield return 0;
        }

        if (didWin && !grid.IsFilling)
        {
            hud.OnGameWin (currentScore) ;
        }
        else
        {
            hud.OnGameLose();
        }
    }
}
