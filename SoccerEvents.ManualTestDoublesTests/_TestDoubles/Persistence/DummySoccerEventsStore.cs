using SoccerEvents.Domain;
using SoccerEvents.Persistence;
using System.Collections.Generic;

namespace SoccerEvents.ManualTestDoublesTests._TestDoubles.Persistence
{
    class DummySoccerEventsStore : ISoccerEventsStore
    {
        public void Save(IEnumerable<SoccerEvent> soccerEvents)
        {
            // no-op
        }
    }
}



















