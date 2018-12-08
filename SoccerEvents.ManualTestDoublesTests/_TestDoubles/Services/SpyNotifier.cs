using SoccerEvents.Services;

namespace SoccerEvents.ManualTestDoublesTests._TestDoubles.Services
{
    public class SpyNotifier : INotifier
    {
        public int NumberOfTimesSendEmailWasCalled { get; private set; }
        public int NumberOfTimesSendSmsWasCalled { get; private set; }

        public void SendEmail(string to, string contents)
        {
            NumberOfTimesSendEmailWasCalled += 1;
        }

        public void SendSms(string phoneNumber, string message)
        {
            NumberOfTimesSendSmsWasCalled += 1;
        }
    }
}














