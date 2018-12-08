using SoccerEvents.Services;
using System;

namespace SoccerEvents.Services
{
    [Obsolete("This class is just for demonstration, do not use it.", true)]
    public class Notifier : INotifier
    {
        public void SendEmail(string to, string contents)
        {
            throw new NotImplementedException();
        }

        public void SendSms(string phoneNumber, string message)
        {
            throw new NotImplementedException();
        }
    }
}