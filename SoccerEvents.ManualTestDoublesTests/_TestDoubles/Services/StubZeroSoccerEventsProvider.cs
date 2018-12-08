using SoccerEvents.Domain;
using SoccerEvents.Services;
using System.Collections.Generic;
using System.Linq;

namespace SoccerEvents.ManualTestDoublesTests._TestDoubles.Services
{
    class StubZeroSoccerEventsProvider : ISoccerEventsProvider
    {
        public IEnumerable<SoccerEvent> GetAll()
        {
            return Enumerable.Empty<SoccerEvent>();
        }
    }
}






















