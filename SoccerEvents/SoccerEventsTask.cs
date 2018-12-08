using SoccerEvents.Domain;
using SoccerEvents.Persistence;
using SoccerEvents.Services;
using System.Collections.Generic;
using System.Linq;

namespace SoccerEvents.SoccerEvents
{
    public class SoccerEventsTask
    {
        ISoccerEventsProvider _provider; ISoccerEventsStore _store; INotifier _notifier;
        string _infoEmailAddress, _infoMessage, _alertEmailAddress, _alertSmsNumber, _alertMessage;

        public SoccerEventsTask(ISoccerEventsProvider provider, ISoccerEventsStore store, INotifier notifier,
            string infoEmailAddress, string infoMessage, string alertEmailAddress, string alertSmsNumber, string alertMessage)
        {
            _provider = provider; _store = store; _notifier = notifier;
            _infoEmailAddress = infoEmailAddress; _infoMessage = infoMessage;
            _alertEmailAddress = alertEmailAddress; _alertSmsNumber = alertSmsNumber; _alertMessage = alertMessage;
        }

        public bool Update()
        {
            IEnumerable<SoccerEvent> soccerEvents = _provider.GetAll();

            if (!soccerEvents.Any())
            {   // No soccer events; send email and SMS ALERTS
                _notifier.SendEmail(_alertEmailAddress, _alertMessage);
                _notifier.SendSms(_alertSmsNumber, _alertMessage);
                return false;
            }
            // there are soccer events, just send an email...
            _notifier.SendEmail(_infoEmailAddress, _infoMessage);
            _store.Save(soccerEvents);
            return true;
        }
    }
}