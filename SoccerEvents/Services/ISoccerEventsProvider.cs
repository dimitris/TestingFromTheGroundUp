using SoccerEvents.Domain;
using System.Collections.Generic;

namespace SoccerEvents.Services
{
    /// <summary>
    /// Provides soccer events
    /// </summary>
    public interface ISoccerEventsProvider
    {
        /// <summary>
        /// Returns all soccer events
        /// </summary>
        IEnumerable<SoccerEvent> GetAll();
    }
}