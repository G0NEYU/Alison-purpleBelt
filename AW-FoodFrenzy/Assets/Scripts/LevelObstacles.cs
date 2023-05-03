using UnityEngine.UI;



public class LevelObstacles : Level
{
    public int numMoves ;
    public GameGrid.PieceType[] obstacleTypes;

    private int movesRemaining = 14;
    private int numObstaclesLeft = 13;
   

    // Start is called before the first frame update
    void Start()
    {
        type = LevelType.OBSTACLE;


        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(numObstaclesLeft);
        hud.SetRemaining(numMoves);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnMove()
    {
        base.OnMove();

        movesRemaining++;

        hud.SetRemaining(numMoves - movesRemaining);

        if (numMoves - movesRemaining == 0 && numObstaclesLeft > 0)
        {
            GameLose();
        }
    }

    public override void OnPieceCleared(GamePiece piece)
    {
        base.OnPieceCleared(piece);

        for (int i = 0; i < obstacleTypes.Length; i++)
        {
            if(obstacleTypes[i] == piece.Type)
            {
                numObstaclesLeft--;
                hud.SetTarget(numObstaclesLeft);
                if (numObstaclesLeft == 0)
                {
                    currentScore += 1000 * (numMoves - movesRemaining);
                    hud.SetScore(currentScore);
                    GameWin();
                }
            }
        }
    }
}
