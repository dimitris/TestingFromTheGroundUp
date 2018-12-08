using SoccerEvents.Domain;
using SoccerEvents.Services;
using System.Collections.Generic;

namespace SoccerEvents.ManualTestDoublesTests._TestDoubles.Services
{
    class StubThreeSoccerEventsProvider : ISoccerEventsProvider
    {
        public IEnumerable<SoccerEvent> GetAll()
        {
            return new SoccerEvent[]
            {
                new SoccerEvent(eventId: 1, homeScore: 2, awayScore: 0, homeTeam: "Bayern Munich", awayTeam: "Arsenal F.C."),
                new SoccerEvent(eventId: 2, homeScore: 1, awayScore: 1, homeTeam: "Manchester United", awayTeam: "Juventus"),
                new SoccerEvent(eventId: 3, homeScore: 3, awayScore: 3, homeTeam: "Porto F.C.", awayTeam: "Barcelona")
            };
        }
    }
}
