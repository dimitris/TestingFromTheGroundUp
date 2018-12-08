using SoccerEvents.Domain;
using System;
using System.Collections.Generic;

namespace SoccerEvents.Services
{
    [Obsolete("This class is just for demonstration, do not use it.", true)]
    public class SoccerEventsProvider : ISoccerEventsProvider
    {
        public IEnumerable<SoccerEvent> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}




















