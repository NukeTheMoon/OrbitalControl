public static class Score {

    public static int Player1Score { get; set; }
    public static int Player2Score { get; set; }

    static Score()
    {
        Player1Score = 0;
        Player2Score = 0;
    }

    public static void Reset()
    {
        Player1Score = 0;
        Player2Score = 0;
    }

}
