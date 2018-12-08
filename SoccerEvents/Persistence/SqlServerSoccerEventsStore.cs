using System;
using System.Collections.Generic;
using SoccerEvents.Domain;

namespace SoccerEvents.Persistence
{
    [Obsolete("This code is just for demonstration, do not use it.", true)]
    public class SqlServerSoccerEventsStore : ISoccerEventsStore
    {
        public void Save(IEnumerable<SoccerEvent> soccerEvents)
        {
            throw new NotImplementedException();
        }
    }
}
