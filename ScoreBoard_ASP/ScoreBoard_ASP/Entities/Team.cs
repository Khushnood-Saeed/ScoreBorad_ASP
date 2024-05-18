namespace ScoreBoard_ASP.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public required string TeamName { get; set; }
        public required int TotalGamesPlayed { get; set; }
        public required int Score { get; set; }
    }
}
