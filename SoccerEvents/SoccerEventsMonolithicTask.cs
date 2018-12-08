using SoccerEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerEvents
{
    [Obsolete("This class is just for demonstration, do not use it.", true)]
    public class SoccerEventsMonolithicTask
    {
        string _infoEmailAddress, _infoMessage, _alertEmailAddress, _alertSmsNumber, _alertMessage;

        public SoccerEventsMonolithicTask(string infoEmailAddress, string infoMessage,
            string alertEmailAddress, string alertSmsNumber, string alertMessage)
        {
            _infoEmailAddress = infoEmailAddress; _infoMessage = infoMessage;
            _alertEmailAddress = alertEmailAddress; _alertSmsNumber = alertSmsNumber; _alertMessage = alertMessage;
        }
        public bool Update()
        {
            IEnumerable<SoccerEvent> soccerEvents = GetAllSoccerEvents();

            if (!soccerEvents.Any())
            {   // No soccer events; send email and SMS ALERTS
                SendEmail(_alertEmailAddress, _alertMessage);
                SendSms(_alertSmsNumber, _alertMessage);
                return false;
            }
            // there are soccer events, just send an email...
            SendEmail(_infoEmailAddress, _infoMessage);
            SaveSoccerEvents(soccerEvents);
            return true;
        }
        private IEnumerable<SoccerEvent> GetAllSoccerEvents()
        {
            throw new NotImplementedException();
        }
        private void SendEmail(string from, string message)
        {
            throw new NotImplementedException();
        }
        private void SendSms(string from, string message)
        {
            throw new NotImplementedException();
        }
        private void SaveSoccerEvents(IEnumerable<SoccerEvent> soccerEvents)
        {
            throw new NotImplementedException();
        }
    }
}