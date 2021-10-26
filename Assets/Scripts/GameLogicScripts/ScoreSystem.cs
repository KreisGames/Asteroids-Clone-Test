public static class ScoreSystem
{
    private static int _score;

    public static void IncreaseScore(int scoreToAdd)
    {
        _score += scoreToAdd;
    }
        
    //Getter for UI
    public static int GetScore()
    {
        return _score;
    }

        
    public static void ResetScore()
    {
        _score = 0;
    }
}