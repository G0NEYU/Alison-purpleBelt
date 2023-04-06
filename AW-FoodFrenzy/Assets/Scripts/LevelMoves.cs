public class LevelMoves : Level
{
    public int numMoves;
    public int targetScore;

    public [] obstacleTypes;

    private int movesUsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        type = LevelType.MOVES;


        for (int i = 0; i < obstacleTypes.Length; i++)
        {
            numObstaclesLeft += grid.GetPiecesOfType(obstacleTypes[1]).Count;
        }


        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(numObstaclesLeft);
        hud.SetRemaining(numMoves);
    }

  
    public override void OnMove()
    {
        base.OnMove();

        movesUsed++;

        if(numMoves - movesUsed == 0)
        {
            if(currentScore >= targetScore)
            {
                GameWin();
            }
            else
            {
                GameLose();
            }
        }
    }
}
