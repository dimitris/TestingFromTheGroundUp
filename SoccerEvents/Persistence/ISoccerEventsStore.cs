using SoccerEvents.Domain;
using System.Collections.Generic;

namespace SoccerEvents.Persistence
{
    /// <summary>
    /// Soccer events store
    /// </summary>
    public interface ISoccerEventsStore
    {
        /// <summary>
        /// Saves soccer events
        /// </summary>
        void Save(IEnumerable<SoccerEvent> soccerEvents);
    }
}