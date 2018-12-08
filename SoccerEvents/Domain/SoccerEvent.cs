namespace SoccerEvents.Domain
{
    /// <summary>
    /// A soccer event
    /// </summary>
    public class SoccerEvent
    {
        public int EventId { get; private set; }
        public string HomeTeam { get; private set; }
        public int HomeScore { get; private set; }
        public string AwayTeam { get; private set; }
        public int AwayScore { get; private set; }

        public SoccerEvent(int eventId, string homeTeam, int homeScore, string awayTeam, int awayScore)
        {
            EventId = eventId;
            HomeTeam = homeTeam;
            HomeScore = homeScore;
            AwayTeam = awayTeam;
            AwayScore = awayScore;
        }
    }
}